using GameDevsConnect.Backend.Middleware;

var builder = WebApplication.CreateBuilder(args);

var sharedConfiguration = ConfigurationHelper.GetConfiguration();
builder.Configuration.AddConfiguration(sharedConfiguration);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<RequestDBContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("GDC"));
});

builder.Services.AddScoped<IRequestRepository, RequestRepository>();

builder.Host.UseSerilog((context, configuration) => configuration.ReadFrom.Configuration(context.Configuration));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<AuthMiddleware>();

app.UseHttpsRedirection();

app.MapEndpoints();

app.Run();
