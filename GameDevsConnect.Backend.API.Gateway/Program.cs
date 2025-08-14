using Microsoft.AspNetCore.Server.Kestrel.Core;

var start = new Startup("Gateway");
var builder = start.Build(args);

var sqlUrl = Environment.GetEnvironmentVariable("SQL_URL") ?? "localhost";
var sqlAdminUsername = Environment.GetEnvironmentVariable("SQL_ADMIN_USERNAME") ?? "sa";
var sqlAdminPassword = Environment.GetEnvironmentVariable("SQL_ADMIN_PASSWORD") ?? "P@ssword1";
var accessKey = Environment.GetEnvironmentVariable("X-Access-Key") ?? "";
var gatewayUrl = Environment.GetEnvironmentVariable("GATEWAY_URL") ?? "https://localhost:7000";

var apiEndpoints = new APIEndpoint[] {
    new("azure", Environment.GetEnvironmentVariable("AZURE_URL") ?? "https://localhost:7001"),
    new("file", Environment.GetEnvironmentVariable("FILE_URL") ?? "https://localhost:7002"),
    new("notification", Environment.GetEnvironmentVariable("NOTIFICATION_URL") ?? "https://localhost:7003"),
    new("post", Environment.GetEnvironmentVariable("POST_URL") ?? "https://localhost:7004"),
    new("project", Environment.GetEnvironmentVariable("PROJECT_URL") ?? "https://localhost:7005"),
    new("profile", Environment.GetEnvironmentVariable("PROFILE_URL") ?? "https://localhost:7006"),
    new("quest", Environment.GetEnvironmentVariable("QUEST_URL") ?? "https://localhost:7007"),
    new("tag", Environment.GetEnvironmentVariable("TAG_URL") ?? "https://localhost:7008"),
    new("user", Environment.GetEnvironmentVariable("USER_URL") ?? "https://localhost:7009")
};

var devModus = Environment.GetEnvironmentVariable("DEVMODUS") ?? "";

ApiMode apiMode = 0;

if (args.Length > 0)
{
    var isNumber = int.TryParse(args[0], out int number);
    if (isNumber)
        apiMode = (ApiMode)number;
}

var yarpConfiguration = new YarpConfiguration(start.APIVersion, gatewayUrl, [.. apiEndpoints], accessKey, !string.IsNullOrEmpty(devModus), apiMode);

builder.WebHost.ConfigureKestrel(options =>
{
    options.ListenAnyIP(7000, listenOptions =>
    {
        listenOptions.Protocols = HttpProtocols.Http1AndHttp2;
        listenOptions.UseHttps(); // TLS aktivieren, wenn du native gRPC willst
    });
});

builder.Services.AddReverseProxy().LoadFromMemory(yarpConfiguration.Routes, yarpConfiguration.Clusters);

builder.Services.Configure<FormOptions>(o => { o.MultipartBodyLengthLimit = 200 * 1024 * 1024; });

builder.Services.AddAuthentication(BearerTokenDefaults.AuthenticationScheme).AddBearerToken();

var app = start.Create(builder);

using (var scope = app.Services.CreateScope())
{
    var serviceProvider = scope.ServiceProvider;
    var gdcDbContext = serviceProvider.GetRequiredService<GDCDbContext>();
    
    var gdcCreated = await gdcDbContext.Database.EnsureCreatedAsync();

    if (!gdcCreated)
    {
        await gdcDbContext.Database.MigrateAsync();
    }
    var assetTags = new List<string>() { "2D", "3D", "LP", "HP", "2D Animation", "3D Animation", "Texture", "BGM" };
    var genreTags = new List<string>() {"RPG", "Action", "Horror", "Adventure", "Jump n Run", "Shooter"};

    try
    {
        assetTags.ForEach(t => gdcDbContext.Tags.Add(new TagDTO() { Tag = t, Type = "Assets" }));
        await gdcDbContext.SaveChangesAsync();
    }
    catch (Exception)
    {
    }
    try
    {
        genreTags.ForEach(t => gdcDbContext.Tags.Add(new TagDTO() { Tag = t, Type = "Genres" }));
        await gdcDbContext.SaveChangesAsync();
    }
    catch (Exception)
    {
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
.WithName(ApiEndpointsV1.Gateway.MetaData.Name.Login)
.WithDescription(ApiEndpointsV1.Gateway.MetaData.Description.Login)
.Produces(StatusCodes.Status200OK);

app.MapGet("/info", () =>
{
    return new
    {
        sqlUrl,
        sqlAdminUsername,
        sqlAdminPassword,
        accessKey,
        swagger_endpoints= new string[]
        {
            Environment.GetEnvironmentVariable("AZURE_URL") + "/swagger",
            Environment.GetEnvironmentVariable("FILE_URL") + "/swagger",
            Environment.GetEnvironmentVariable("NOTIFICATION_URL") + "/swagger",
            Environment.GetEnvironmentVariable("POST_URL") + "/swagger",
            Environment.GetEnvironmentVariable("PROJECT_URL") + "/swagger",
            Environment.GetEnvironmentVariable("PROFILE_URL") + "/swagger",
            Environment.GetEnvironmentVariable("QUEST_URL") + "/swagger",
            Environment.GetEnvironmentVariable("TAG_URL") + "/swagger",
            Environment.GetEnvironmentVariable("USER_URL") + "/swagger"
        }
    };
});

app.UseAuthentication();
app.UseAuthorization();

app.MapReverseProxy();

app.Run();