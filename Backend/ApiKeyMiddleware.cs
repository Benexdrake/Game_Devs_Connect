namespace Backend;

public class ApiKeyMiddleware(RequestDelegate next, IConfiguration configuration)
{
    private readonly RequestDelegate _next = next;
    private readonly string? _apiKey = configuration.GetSection("ApiToken").Value;

    public async Task InvokeAsync(HttpContext context)
    {
        if (context.Request.Path.StartsWithSegments("/swagger"))
        {
            await _next(context);
            return;
        }

        string referer = context.Request.Headers["Referer"]+"";

        if (referer.Contains("/swagger/"))
        {
            await _next(context);
            return;
        }

        string? apiKeyHeader = context.Request.Headers?.Authorization;

        if (string.IsNullOrEmpty(apiKeyHeader) || apiKeyHeader != _apiKey)
        {
            context.Response.StatusCode = 401; // Unauthorized
            await context.Response.WriteAsync("Geh weg...");
            return;
        }

        await _next(context);
    }
}