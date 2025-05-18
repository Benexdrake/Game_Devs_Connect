using GameDevsConnect.Backend.API.Auth.Repository;
using GameDevsConnect.Backend.API.Gateway.Repository;
using GameDevsConnect.Backend.Shared;
using GameDevsConnect.Backend.Shared.Data;
using GameDevsConnect.Backend.Shared.Models;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Serilog;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text.Json;

var builder = WebApplication.CreateBuilder(args);

// Get appsettings.json from Shared
var sharedConfiguration = ConfigurationHelper.GetConfiguration();
builder.Configuration.AddConfiguration(sharedConfiguration);

builder.Services.AddDbContext<AuthDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("Auth"));
});

builder.Services.AddDbContext<GDCDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("GDC"));
});

builder.AddServiceDefaults();

builder.Services.AddReverseProxy().LoadFromConfig(builder.Configuration.GetSection("YARP"));

builder.Services.Configure<FormOptions>(o => { o.MultipartBodyLengthLimit = 200 * 1024 * 1024; });

builder.Services.AddScoped<IAuthRepository, AuthRepository>();

var app = builder.Build();

app.MapDefaultEndpoints();
app.UseHttpsRedirection();


    using (var scope = app.Services.CreateScope())
    {
        var serviceProvider = scope.ServiceProvider;
        try
        {
            var gdcDbContext = serviceProvider.GetRequiredService<GDCDbContext>();
            var authDbContext = serviceProvider.GetRequiredService<AuthDbContext>();
            gdcDbContext.Database.Migrate();
            authDbContext.Database.Migrate();

            var tags = new List<string>() {"2D","3D", "LP", "HP", "2D Animation", "3D Animation", "Texture", "BGM" };

            tags.ForEach(t => gdcDbContext.Tags.Add(new TagModel() { Id=0, Tag=t }));

            await gdcDbContext.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Fehler bei der Datenbankmigration: {ex.Message}");
        }
    }
if (app.Environment.IsDevelopment())
{
}


app.Use(async (context, next) =>
{
    string? apiKey = context.Request.Headers.Authorization;

    //string? userId = context.Request.Headers["ID"];
    string? expectedApiKey = app.Configuration["LoginApiKey"];
    var endpoint = context.Request.Path.Value.ToLower();

    if (string.IsNullOrEmpty(apiKey))
    {
        context.Response.StatusCode = 400;
        await context.Response.WriteAsync("Access Denied");
    }

    if (!string.IsNullOrEmpty(endpoint) && (endpoint.Equals("/login") || endpoint.Equals("/logout")))
    {
        if (!string.IsNullOrEmpty(expectedApiKey) && apiKey.Equals(expectedApiKey))
        {
            await next(context);
            return;
        }
    }

    var repo = context.RequestServices.GetService<IAuthRepository>();
    if (repo is null)
        return;

    var auth = await repo.AuthenticateAsync2(apiKey);

    if (auth)
    {
        await next(context);
        return;
    }

    //try
    //{
    //    var endpoint = context.Request.Path.Value.ToLower();
    //    if (!string.IsNullOrEmpty(endpoint) && (endpoint.Equals("/login") || endpoint.Equals("/logout")))
    //    {
    //        string? apiKey = context.Request.Headers.Authorization;
    //        string? expectedApiKey = app.Configuration["LoginApiKey"];
    //        if (!string.IsNullOrEmpty(apiKey) && (!string.IsNullOrEmpty(expectedApiKey) && apiKey.Contains(expectedApiKey)))
    //        {
    //            await next(context);
    //            return;
    //        }
    //    }

    //    var repo = context.RequestServices.GetService<IAuthRepository>();
    //    if (repo is null)
    //        return;

    //    string? jwtTokenString = context.Request.Query["authModel"].FirstOrDefault();

    //    if (string.IsNullOrEmpty(jwtTokenString))
    //    {
    //        context.Response.StatusCode = 400;
    //        await context.Response.WriteAsync("Access Denied");
    //        return;
    //    }

    //    var tokenHandler = new JwtSecurityTokenHandler();
    //    SecurityToken? validatedToken = null;
    //    ClaimsPrincipal? principal = null;

    //    var tokenValidationParameters = new TokenValidationParameters
    //    {
    //        ValidateIssuerSigningKey = false,
    //        ValidateIssuer = false,
    //        ValidateAudience = false,
    //        ClockSkew = TimeSpan.Zero
    //    };

    //    principal = tokenHandler.ValidateToken(jwtTokenString, tokenValidationParameters, out validatedToken);

    //    if (validatedToken is JwtSecurityToken jwtToken)
    //    {
    //        var userIdClaim = jwtToken.Claims.FirstOrDefault(c => c.Type == "userid")?.Value;
    //        var tokenClaim = jwtToken.RawData;
    //        var expiresClaim = jwtToken.Claims.FirstOrDefault(c => c.Type == "exp")?.Value;

    //        if (userIdClaim == null || tokenClaim == null || expiresClaim == null)
    //        {
    //            context.Response.StatusCode = 400;
    //            await context.Response.WriteAsync("Access Denied");
    //            return;
    //        }

    //        if (long.TryParse(expiresClaim, out long expiresUnix))
    //        {
    //            var authModel = new AuthModel
    //            {
    //                UserId = userIdClaim,
    //                Token = tokenClaim,
    //                Expires = expiresUnix
    //            };

    //            var response = await repo.AuthenticateAsync(authModel);
    //            if (response)
    //            {
    //                await next(context);
    //                return;
    //            }
    //        }

    //    }
    //}
    //catch (Exception ex)
    //{
    //    Log.Error(ex.Message.ToString());
    //}

    //context.Response.StatusCode = 400;
    //await context.Response.WriteAsync("Access Denied");
});

app.MapPost("/login", async (IAuthRepository repo, AuthModel auth) =>
{
    await repo.UpsertAsync(auth);
    return "";
});

app.MapPost("/logout", async (IAuthRepository repo, AuthModel auth) =>
{
    await repo.DeleteAsync(auth);
    return "";
});

app.MapReverseProxy();

app.Run();