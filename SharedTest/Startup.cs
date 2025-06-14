﻿using GameDevsConnect.Backend.Shared;
using GameDevsConnect.Backend.Shared.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Net.Http.Headers;
using Serilog;

namespace SharedTest;

public class Startup<I,R> 
    where I : class 
    where R : class, I
{

    public string AccessKey { get; set; } = string.Empty;

    private WebApplication Build(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.AddServiceDefaults();
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        var sqlUrl           = Environment.GetEnvironmentVariable("SQL_URL") ?? "localhost";
        var sqlAdminUsername = Environment.GetEnvironmentVariable("SQL_ADMIN_USERNAME") ?? "sa";
        var sqlAdminPassword = Environment.GetEnvironmentVariable("SQL_ADMIN_PASSWORD") ?? "P@ssword1";
        AccessKey            = Environment.GetEnvironmentVariable("X-Access-Key") ?? "";

        builder.Services.AddDbContext<GDCDbContext>(options => { options.UseSqlServer($"Server={sqlUrl};Database=GDC;User ID={sqlAdminUsername};Password={sqlAdminPassword};TrustServerCertificate=True"); });
        builder.Services.AddScoped<I, R>();
        builder.Services.AddHealthChecks();
        builder.Services.AddResponseCaching();

        builder.Host.UseSerilog((context, configuration) => configuration.MinimumLevel.Information().WriteTo.Console());

        return builder.Build();
    }

    public WebApplication Create(string[] args)
    {
        var app = Build(args);
        app.MapDefaultEndpoints();

        app.MapHealthChecks(ApiEndpoints.Health);

        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.UseResponseCaching();

        app.Use(async (context, next) =>
        {
            if (app.Environment.IsDevelopment())
            {
                await next();
                return;
            }

            if (context.Request.Headers.TryGetValue("X-Access-Key", out var value) && value.Equals(AccessKey))
            {
                context.Request.Headers["X-Access-Key"] = "-";
                context.Response.GetTypedHeaders().CacheControl = new CacheControlHeaderValue
                {
                    Public = true,
                    MaxAge = TimeSpan.FromSeconds(30)
                };

                context.Response.Headers[HeaderNames.Vary] = "User-Agent";

                await next();
                return;
            }

            context.Response.StatusCode = StatusCodes.Status403Forbidden;
            await context.Response.WriteAsync("Access denied.");
            return;
        });

        app.MapGet("", () => "Hello from Tag");

        return app;
    }
}
