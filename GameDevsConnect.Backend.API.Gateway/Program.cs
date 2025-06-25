var start = new Startup("Gateway");
var builder = start.Build(args);

var sqlUrl = Environment.GetEnvironmentVariable("SQL_URL") ?? "localhost";
var sqlAdminUsername = Environment.GetEnvironmentVariable("SQL_ADMIN_USERNAME") ?? "sa";
var sqlAdminPassword = Environment.GetEnvironmentVariable("SQL_ADMIN_PASSWORD") ?? "P@ssword1";
var accessKey = Environment.GetEnvironmentVariable("X-Access-Key") ?? "";
var azureUrl = Environment.GetEnvironmentVariable("AZURE_URL") ?? "http://localhost:7001";
var commentUrl = Environment.GetEnvironmentVariable("COMMENT_URL") ?? "http://localhost:7002";
var fileUrl = Environment.GetEnvironmentVariable("FILE_URL") ?? "http://localhost:7003";
var notificationUrl = Environment.GetEnvironmentVariable("NOTIFICATION_URL") ?? "http://localhost:7004";
var projectUrl = Environment.GetEnvironmentVariable("PROJECT_URL") ?? "http://localhost:7005";
var profileUrl = Environment.GetEnvironmentVariable("PROFILE_URL") ?? "http://localhost:7006";
var requestUrl = Environment.GetEnvironmentVariable("REQUEST_URL") ?? "http://localhost:7007";
var tagUrl = Environment.GetEnvironmentVariable("TAG_URL") ?? "http://localhost:7008";
var userUrl = Environment.GetEnvironmentVariable("USER_URL") ?? "http://localhost:7009";

var yarpConfiguration = new YarpConfiguration(azureUrl, commentUrl, fileUrl, notificationUrl, projectUrl, profileUrl, requestUrl, tagUrl, userUrl, accessKey);

builder.Services.AddReverseProxy().LoadFromMemory(yarpConfiguration.Routes, yarpConfiguration.Clusters);

builder.Services.Configure<FormOptions>(o => { o.MultipartBodyLengthLimit = 200 * 1024 * 1024; });

builder.Services.AddAuthentication(BearerTokenDefaults.AuthenticationScheme).AddBearerToken();

var app = start.Create(builder);

using (var scope = app.Services.CreateScope())
{
    var serviceProvider = scope.ServiceProvider;
    try
    {
        var gdcDbContext = serviceProvider.GetRequiredService<GDCDbContext>();

        var gdcCreated = await gdcDbContext.Database.EnsureCreatedAsync();

        if (!gdcCreated)
        {
            await gdcDbContext.Database.MigrateAsync();
            var tags = new List<string>() { "2D", "3D", "LP", "HP", "2D Animation", "3D Animation", "Texture", "BGM" };

            tags.ForEach(t => gdcDbContext.Tags.Add(new TagModel() { Id = 0, Tag = t }));

            await gdcDbContext.SaveChangesAsync();
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Fehler bei der Datenbankmigration: {ex.Message}");
    }
}

app.MapGet(ApiEndpointsV1.Gateway.Login, () =>
    Results.SignIn(
        new ClaimsPrincipal(
            new ClaimsIdentity(
                [ new Claim("sub", Guid.NewGuid().ToString()) ],
                BearerTokenDefaults.AuthenticationScheme
            )
        ),
        authenticationScheme: BearerTokenDefaults.AuthenticationScheme
))
.WithName(ApiEndpointsV1.Gateway.MetaData.Login)
.Produces(StatusCodes.Status200OK);

app.MapGet("/info", () =>
{
    return new
    {
        sqlUrl,
        sqlAdminUsername,
        sqlAdminPassword,
        accessKey,
        routes = yarpConfiguration.Routes,
        clusters = yarpConfiguration.Clusters
    };
});

app.UseAuthentication();
app.UseAuthorization();

app.MapReverseProxy();

app.Run();