using GameDevsConnect.Backend.API.Auth.Repository;
using GameDevsConnect.Backend.API.Gateway.Repository;
using GameDevsConnect.Backend.Shared;
using GameDevsConnect.Backend.Shared.Data;
using GameDevsConnect.Backend.Shared.Models;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.EntityFrameworkCore;
using Serilog;
using System.Text.Json;

var builder = WebApplication.CreateBuilder(args);

// Get appsettings.json from Shared
var sharedConfiguration = ConfigurationHelper.GetConfiguration();
builder.Configuration.AddConfiguration(sharedConfiguration);

builder.Services.AddDbContext<AuthDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("Auth"));
});

builder.AddServiceDefaults();

builder.Services.AddReverseProxy().LoadFromConfig(builder.Configuration.GetSection("YARP"));

builder.Services.Configure<FormOptions>(o => { o.MultipartBodyLengthLimit = 200 * 1024 * 1024; });

builder.Services.AddScoped<IAuthRepository, AuthRepository>();

var app = builder.Build();

app.MapDefaultEndpoints();
app.UseHttpsRedirection();

app.Use(async (context, next) =>
{
    try
    {
        var endpoint = context.Request.Path.Value;
        if (!string.IsNullOrEmpty(endpoint) && (endpoint.Equals("/Login") || endpoint.Equals("/Logout")))
        {
            string? apiKey = context.Request.Headers.Authorization;
            string? expectedApiKey = app.Configuration["LoginApiKey"];
            if (!string.IsNullOrEmpty(apiKey) && (!string.IsNullOrEmpty(expectedApiKey) && apiKey.Contains(expectedApiKey)))
            {
                await next(context);
                return;
            }
        }

        var repo = context.RequestServices.GetService<IAuthRepository>();
        if (repo is null)
            return;

        var authModel = await JsonSerializer.DeserializeAsync<AuthModel>(context.Request.Body);
        if (authModel is null)
            return;
            
        var response = await repo.AuthenticateAsync(authModel);
        if (response == true)
        {
            await next(context);
            return;
        }
    }
    catch (Exception ex)
    {
        Log.Error(ex.Message.ToString());
    }


    context.Response.StatusCode = 401;
    await context.Response.WriteAsync("Unauthorized: Ung�ltiger API-Schl�ssel");
});

app.MapGet("/", () => "Hello im a Gateway");

app.MapPost("/Login", async (IAuthRepository repo, AuthModel auth) =>
{
    await repo.UpsertAsync(auth);
    return "";
});

app.MapPost("Logout", async (IAuthRepository repo, AuthModel auth) =>
{
    await repo.DeleteAsync(auth);
    return "";
});

app.MapReverseProxy();

app.Run();