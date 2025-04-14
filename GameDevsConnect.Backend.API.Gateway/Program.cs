using GameDevsConnect.Backend.Shared;
using Microsoft.AspNetCore.Authentication.BearerToken;
using Microsoft.AspNetCore.Http.Features;
using System.Security.Claims;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddReverseProxy().LoadFromConfig(builder.Configuration.GetSection("YARP"));

builder.Services.AddAuthentication(BearerTokenDefaults.AuthenticationScheme).AddBearerToken();

builder.Services.Configure<FormOptions>(o => { o.MultipartBodyLengthLimit = 200 * 1024 * 1024; });

// Get appsettings.json from Shared
var sharedConfiguration = ConfigurationHelper.GetConfiguration();
builder.Configuration.AddConfiguration(sharedConfiguration);


var app = builder.Build();
app.UseHttpsRedirection();

app.Use(async (context, next) =>
{
    string? apiKey = context.Request.Headers.Authorization;
    string? expectedApiKey = "Bearer " + app.Configuration["LoginApiKey"];

    if (string.IsNullOrEmpty(apiKey) || apiKey != expectedApiKey)
    {
        context.Response.StatusCode = 401;
        await context.Response.WriteAsync("Unauthorized: Ungültiger API-Schlüssel");
        return;
    }

    await next(context);
});

app.MapGet("/", () => "Hello im a Gateway");

app.MapGet("/login", () =>
{
    return Results.SignIn(
        new ClaimsPrincipal(
            new ClaimsIdentity(
                [new Claim("sub", Guid.NewGuid().ToString())],
                BearerTokenDefaults.AuthenticationScheme)),
        authenticationScheme: BearerTokenDefaults.AuthenticationScheme);
});

app.UseAuthentication();

app.UseAuthorization();

app.MapReverseProxy();

app.Run();