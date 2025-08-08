using GameDevsConnect.Backend.API.Configuration.Application.Data;
using GameDevsConnect.Backend.API.User.gRPC.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.AddServiceDefaults();

// Add services to the container.
builder.Services.AddGrpc();
builder.Services.AddScoped<IUserRepository, UserRepository>();


var sqlUrl = Environment.GetEnvironmentVariable("SQL_URL") ?? "localhost";
var sqlAdminUsername = Environment.GetEnvironmentVariable("SQL_ADMIN_USERNAME") ?? "sa";
var sqlAdminPassword = Environment.GetEnvironmentVariable("SQL_ADMIN_PASSWORD") ?? "P@ssword1";

builder.Services.AddDbContext<GDCDbContext>(options => { options.UseSqlServer($"Server={sqlUrl};Database=GDC;User ID={sqlAdminUsername};Password={sqlAdminPassword};TrustServerCertificate=True"); });
//builder.Services.AddHealthChecks();


var app = builder.Build();

app.MapDefaultEndpoints();

app.MapGrpcService<UserRPCService>();
app.MapGet("/", () => "Hello gRPC World!!!");

app.Run();
