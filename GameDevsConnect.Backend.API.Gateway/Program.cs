using GameDevsConnect.Backend.API.Configuration.Application.Data;

var start = new Startup("Gateway");
var builder = start.Build(args);

var sqlUrl = Environment.GetEnvironmentVariable("SQL_URL") ?? "localhost";
var sqlAdminUsername = Environment.GetEnvironmentVariable("SQL_ADMIN_USERNAME") ?? "sa";
var sqlAdminPassword = Environment.GetEnvironmentVariable("SQL_ADMIN_PASSWORD") ?? "P@ssword1";
var accessKey = Environment.GetEnvironmentVariable("X-Access-Key") ?? "";
var gatewayUrl = Environment.GetEnvironmentVariable("GATEWAY_URL") ?? "https://localhost:7000";

var apiEndpoints = new APIEndpoint[] {
    new("azure", Environment.GetEnvironmentVariable("AZURE_URL") ?? "http://localhost:7001"),
    new("file", Environment.GetEnvironmentVariable("FILE_URL") ?? "http://localhost:7002"),
    new("notification", Environment.GetEnvironmentVariable("NOTIFICATION_URL") ?? "http://localhost:7003"),
    new("post", Environment.GetEnvironmentVariable("POST_URL") ?? "http://localhost:7004"),
    new("project", Environment.GetEnvironmentVariable("PROJECT_URL") ?? "http://localhost:7005"),
    new("profile", Environment.GetEnvironmentVariable("PROFILE_URL") ?? "http://localhost:7006"),
    new("quest", Environment.GetEnvironmentVariable("QUEST_URL") ?? "http://localhost:7007"),
    new("tag", Environment.GetEnvironmentVariable("TAG_URL") ?? "http://localhost:7008"),
    new("user", Environment.GetEnvironmentVariable("USER_URL") ?? "http://localhost:7009")
};

var devModus = Environment.GetEnvironmentVariable("DEVMODUS") ?? "";

var yarpConfiguration = new YarpConfiguration(start.APIVersion, gatewayUrl, [.. apiEndpoints], accessKey, !string.IsNullOrEmpty(devModus));

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

            tags.ForEach(t => gdcDbContext.Tags.Add(new TagDTO() { Tag = t, Type = "Assets" }));

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