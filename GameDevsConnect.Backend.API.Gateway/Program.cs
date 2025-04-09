using GameDevsConnect.Backend.Shared;
using Microsoft.AspNetCore.Authentication.BearerToken;
using System.Security.Claims;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddReverseProxy().LoadFromConfig(builder.Configuration.GetSection("YARP"));

builder.Services.AddAuthentication(BearerTokenDefaults.AuthenticationScheme).AddBearerToken();

// Get appsettings.json from Shared
var sharedConfiguration = ConfigurationHelper.GetConfiguration();
builder.Configuration.AddConfiguration(sharedConfiguration);

var app = builder.Build();

app.UseHttpsRedirection();

app.MapGet("/", () => "Hello im a Gateway");

app.MapGet("login/{token}", (string token="") =>
{
    if (token.Equals(app.Configuration.GetValue<string>("ApiToken")))
        return Results.SignIn(
        new ClaimsPrincipal(
            new ClaimsIdentity(
                [new Claim("sub", Guid.NewGuid().ToString())],
                BearerTokenDefaults.AuthenticationScheme)),
        authenticationScheme: BearerTokenDefaults.AuthenticationScheme);
    else
        return Results.Ok("Go Away");
});

app.UseAuthentication();

app.UseAuthorization();

app.MapReverseProxy();

app.Run();