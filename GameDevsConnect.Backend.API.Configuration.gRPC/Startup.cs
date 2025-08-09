namespace GameDevsConnect.Backend.API.Configuration.gRPC;

public class Startup(string name)
{
    private readonly string _name = name;

    public WebApplicationBuilder Build(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.AddServiceDefaults();

        builder.Services.AddGrpc();

        var sqlUrl = Environment.GetEnvironmentVariable("SQL_URL") ?? "localhost";
        var sqlAdminUsername = Environment.GetEnvironmentVariable("SQL_ADMIN_USERNAME") ?? "sa";
        var sqlAdminPassword = Environment.GetEnvironmentVariable("SQL_ADMIN_PASSWORD") ?? "P@ssword1";

        builder.Services.AddDbContext<GDCDbContext>(options => { options.UseSqlServer($"Server={sqlUrl};Database=GDC;User ID={sqlAdminUsername};Password={sqlAdminPassword};TrustServerCertificate=True"); });
        builder.Services.AddHealthChecks();

        builder.Services.AddGrpcSwagger();
        builder.Services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1",
                new OpenApiInfo { Title = "gRPC transcoding", Version = "v1" });
        });

        return builder;
    }

    public WebApplication Create(WebApplicationBuilder build)
    {
        var app = build.Build();

        app.MapDefaultEndpoints();

        app.UseSwagger();
        app.UseSwaggerUI(c =>
        {
            c.SwaggerEndpoint("/swagger/v1/swagger.json", "V1");
        });

        app.Use(async (context, next) =>
        {
            Console.WriteLine("Middleware");
            await next();
        });

        app.MapGet("/", () => $"Hello from {_name}");

        return app;
    }
}
