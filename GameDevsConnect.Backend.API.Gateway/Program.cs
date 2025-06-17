var start = new Startup();
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

//builder.Services.AddDbContext<AuthDbContext>(options =>
//{
//    options.UseSqlServer($"Server={sqlUrl};Database=Auth;User ID={sqlAdminUsername};Password={sqlAdminPassword};TrustServerCertificate=True");
//});

var yarpConfiguration = new YarpConfiguration(azureUrl, commentUrl, fileUrl, notificationUrl, projectUrl, profileUrl, requestUrl, tagUrl, userUrl, accessKey);

builder.Services.AddReverseProxy().LoadFromMemory(yarpConfiguration.Routes, yarpConfiguration.Clusters);

builder.Services.Configure<FormOptions>(o => { o.MultipartBodyLengthLimit = 200 * 1024 * 1024; });

//builder.Services.AddScoped<IAuthRepository, AuthRepository>();

var app = start.Create(builder);

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

using (var scope = app.Services.CreateScope())
{
    var serviceProvider = scope.ServiceProvider;
    try
    {
        var gdcDbContext = serviceProvider.GetRequiredService<GDCDbContext>();
        //var authDbContext = serviceProvider.GetRequiredService<AuthDbContext>();

        var gdcCreated = await gdcDbContext.Database.EnsureCreatedAsync();
        //var authCreated = await authDbContext.Database.EnsureCreatedAsync();

        if (!gdcCreated)
        {
            await gdcDbContext.Database.MigrateAsync();
            var tags = new List<string>() { "2D", "3D", "LP", "HP", "2D Animation", "3D Animation", "Texture", "BGM" };

            tags.ForEach(t => gdcDbContext.Tags.Add(new TagModel() { Id = 0, Tag = t }));

            await gdcDbContext.SaveChangesAsync();
        }

        //if (!authCreated)
        //    await authDbContext.Database.MigrateAsync();
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Fehler bei der Datenbankmigration: {ex.Message}");
    }
}

// Endpoints

//app.Use(async (context, next) =>
//{
//    await next(context);
//    return;
//    //if(app.Environment.IsDevelopment())
//    //{
//    //}

//    string apiKey = context.Request.Headers.Authorization! + "";

//    string expectedApiKey = app.Configuration["LoginApiKey"]! + "";

//    var endpoint = context.Request.Path.Value!.ToLower() + "";

//    if (string.IsNullOrEmpty(apiKey))
//    {
//        context.Response.StatusCode = 400;
//        await context.Response.WriteAsync("Access Denied");
//    }

//    if (endpoint.Equals("/login"))
//    {
//        if (apiKey.Equals(expectedApiKey))
//        {
//            await next(context);
//            return;
//        }
//        else
//        {
//            context.Response.StatusCode = 400;
//            await context.Response.WriteAsync("Access Denied");
//        }
//    }
//    else if (endpoint.Equals("/logout"))
//    {
//        await next(context);
//        return;
//    }

//    var repo = context.RequestServices.GetService<IAuthRepository>();

//    if (repo is null)
//    {
//        Log.Error("Cant load AuthRepository Service");
//        return;
//    }

//    var auth = await repo.AuthenticateAsync(apiKey);

//    if (auth.Success)
//    {
//        await next(context);
//        return;
//    }

//    context.Response.StatusCode = 400;
//    await context.Response.WriteAsync("Access Denied");
//});

// app.MapPost(ApiEndpointsV1.Gateway.Login, async ([FromServices] IAuthRepository repo, [FromBody] AuthModel auth) =>
// {
//     await repo.UpsertAsync(auth);
//     return;
// })
// .WithName(ApiEndpointsV1.Gateway.MetaData.Login)
// .Produces(StatusCodes.Status200OK);

// app.MapPost(ApiEndpointsV1.Gateway.Logout, async ([FromServices] IAuthRepository repo, [FromBody] AuthModel auth) =>
// {
//     await repo.DeleteAsync(auth);
//     return;
// })
// .WithName(ApiEndpointsV1.Gateway.MetaData.Logout)
// .Produces(StatusCodes.Status200OK);

app.MapReverseProxy();

app.Run();