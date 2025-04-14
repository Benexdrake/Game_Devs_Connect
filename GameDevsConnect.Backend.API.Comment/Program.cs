using GameDevsConnect.Backend.Shared.Data;

var builder = WebApplication.CreateBuilder(args);

builder.AddServiceDefaults();

var sharedConfiguration = ConfigurationHelper.GetConfiguration();
builder.Configuration.AddConfiguration(sharedConfiguration);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<GDCDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("GDC"));
});

builder.Services.AddScoped<ICommentRepository, CommentRepository>();

builder.Host.UseSerilog((context, configuration) => configuration.ReadFrom.Configuration(context.Configuration));

var app = builder.Build();

app.MapDefaultEndpoints();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//app.UseMiddleware<AuthMiddleware>();

app.UseHttpsRedirection();

app.MapEndpoints();

app.Run();
