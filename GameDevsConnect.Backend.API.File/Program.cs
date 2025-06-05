var builder = WebApplication.CreateBuilder(args);

builder.AddServiceDefaults();

var sharedConfiguration = ConfigurationHelper.GetConfiguration();
builder.Configuration.AddConfiguration(sharedConfiguration);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<GDCDbContext>(options => { options.UseSqlServer(builder.Configuration.GetConnectionString("GDC")); });

builder.Services.AddScoped<IFileRepository, FileRepository>();

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
    context.Response.GetTypedHeaders().CacheControl = new CacheControlHeaderValue
    {
        Public = true,
        MaxAge = TimeSpan.FromSeconds(30)
    };

    context.Response.Headers[HeaderNames.Vary] = "User-Agent";

    await next();
});

app.Run();
