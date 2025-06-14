using Microsoft.Net.Http.Headers;

var builder = WebApplication.CreateBuilder(args);

builder.AddServiceDefaults();

var sharedConfiguration = ConfigurationHelper.GetConfiguration();
builder.Configuration.AddConfiguration(sharedConfiguration);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<GDCDbContext>(options => { options.UseSqlServer(builder.Configuration.GetConnectionString("GDC")); });

builder.Services.AddScoped<IProjectRepository, ProjectRepository>();

builder.Host.UseSerilog((context, configuration) => configuration.ReadFrom.Configuration(context.Configuration));

builder.Services.AddHealthChecks();

builder.Services.AddResponseCaching();

var app = builder.Build();

app.MapDefaultEndpoints();

app.MapHealthChecks(ApiEndpoints.Health);

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapEndpointsV1();

app.UseResponseCaching();

app.Use(async (context, next) =>
{
    if (app.Environment.IsDevelopment())
    {
        await next();
        return;
    }

    if (context.Request.Headers.TryGetValue("X-Access-Key", out var value) && value == app.Configuration["X-Access-Key"])
    {
        context.Request.Headers["X-Access-Key"] = "-";
        context.Response.GetTypedHeaders().CacheControl = new CacheControlHeaderValue
        {
            Public = true,
            MaxAge = TimeSpan.FromSeconds(30)
        };

        context.Response.Headers[HeaderNames.Vary] = "User-Agent";

        await next();
        return;
    }

    context.Response.StatusCode = StatusCodes.Status403Forbidden;
    await context.Response.WriteAsync("Access denied.");
    return;
});

app.MapGet("", () => "Hello from Tag");

app.Run();
