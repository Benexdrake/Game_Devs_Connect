using GameDevsConnect.Backend.Middleware;

var builder = WebApplication.CreateBuilder(args);

var sharedConfiguration = ConfigurationHelper.GetConfiguration();
builder.Configuration.AddConfiguration(sharedConfiguration);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AuthDBContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("Auth"));
});

builder.Services.AddScoped<IAuthRepository, AuthRepository>();

builder.Host.UseSerilog((context, configuration) => configuration.ReadFrom.Configuration(context.Configuration));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<AuthMiddleware>();

app.UseHttpsRedirection();

app.MapEndpoints();

app.Run();
