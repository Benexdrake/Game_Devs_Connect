var builder = WebApplication.CreateBuilder(args);

var sharedConfiguration = ConfigurationHelper.GetConfiguration();
builder.Configuration.AddConfiguration(sharedConfiguration);

builder.Services.AddDbContext<AuthDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("Auth"));
});

builder.Services.AddDbContext<GDCDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("GDC"));
});

builder.Services.AddHealthChecks();

builder.AddServiceDefaults();

builder.Services.AddReverseProxy().LoadFromConfig(builder.Configuration.GetSection("YARP"));

builder.Services.Configure<FormOptions>(o => { o.MultipartBodyLengthLimit = 200 * 1024 * 1024; });

builder.Services.AddScoped<IAuthRepository, AuthRepository>();

var app = builder.Build();

app.MapDefaultEndpoints();
app.UseHttpsRedirection();

app.MapHealthChecks(ApiEndpoints.Health);

if (app.Environment.IsDevelopment())
{
    using (var scope = app.Services.CreateScope())
    {
        var serviceProvider = scope.ServiceProvider;
        try
        {
            var gdcDbContext = serviceProvider.GetRequiredService<GDCDbContext>();
            var authDbContext = serviceProvider.GetRequiredService<AuthDbContext>();

            var gdcCreated = await gdcDbContext.Database.EnsureCreatedAsync();
            var authCreated = await authDbContext.Database.EnsureCreatedAsync();

            if (!gdcCreated)
                gdcDbContext.Database.Migrate();
            
            if(!authCreated)
                authDbContext.Database.Migrate();

            var tags = new List<string>() {"2D","3D", "LP", "HP", "2D Animation", "3D Animation", "Texture", "BGM" };

            tags.ForEach(t => gdcDbContext.Tags.Add(new TagModel() { Id=0, Tag=t }));

            await gdcDbContext.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Fehler bei der Datenbankmigration: {ex.Message}");
        }
    }
}

app.Use(async (context, next) =>
{
    if(app.Environment.IsDevelopment())
    {
        await next(context);
        return;
    }

    string apiKey = context.Request.Headers.Authorization! + "";

    string expectedApiKey = app.Configuration["LoginApiKey"]! + "";

    var endpoint = context.Request.Path.Value!.ToLower() + "";

    if (string.IsNullOrEmpty(apiKey))
    {
        context.Response.StatusCode = 400;
        await context.Response.WriteAsync("Access Denied");
    }

    if (endpoint.Equals("/login"))
    {
        if (apiKey.Equals(expectedApiKey))
        {
            await next(context);
            return;
        }
        else
        {
            context.Response.StatusCode = 400;
            await context.Response.WriteAsync("Access Denied");
        }
    }
    else if(endpoint.Equals("/logout"))
    {
        await next(context);
        return;
    }

    var repo = context.RequestServices.GetService<IAuthRepository>();

    if (repo is null)
    {
        Log.Error("Cant load AuthRepository Service");
        return;
    }

    var auth = await repo.AuthenticateAsync(apiKey);

    if (auth.Success)
    {
        await next(context);
        return;
    }

    context.Response.StatusCode = 400;
    await context.Response.WriteAsync("Access Denied");
});

app.MapPost(ApiEndpoints.Gateway.Login, async ([FromServices] IAuthRepository repo, [FromBody] AuthModel auth) =>
{
    await repo.UpsertAsync(auth);
    return;
})
.WithName(ApiEndpoints.Gateway.MetaData.Login)
.Produces(StatusCodes.Status200OK);

app.MapPost(ApiEndpoints.Gateway.Logout, async ([FromServices] IAuthRepository repo, [FromBody] AuthModel auth) =>
{
    await repo.DeleteAsync(auth);
    return;
})
.WithName(ApiEndpoints.Gateway.MetaData.Logout)
.Produces(StatusCodes.Status200OK);

app.MapReverseProxy();

app.Run();