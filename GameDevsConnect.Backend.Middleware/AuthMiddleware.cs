using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace GameDevsConnect.Backend.Middleware
{
    public class AuthMiddleware
    {
        public AuthMiddleware(RequestDelegate next, IConfiguration configuration)
        {
            _next = next;
            _apiKey = configuration.GetSection("ApiToken").Value;

            _context = new AuthContext(new DbContextOptionsBuilder<AuthContext>().UseSqlServer(configuration.GetConnectionString("Auth")).Options);
        }

        private readonly RequestDelegate _next;
        private readonly string? _apiKey;
        private AuthContext _context;

        public async Task InvokeAsync(HttpContext context)
        {
            if (context.Request.Method == "GET")
            {
                await _next(context);
                return;
            }

            if (context.Request.Path.StartsWithSegments("/swagger"))
            {
                await _next(context);
                return;
            }

            string referer = context.Request.Headers["Referer"] + "";

            if (referer.Contains("/swagger/"))
            {
                await _next(context);
                return;
            }

            string? apiKey = context.Request.Headers?["APIKey"];

            if (apiKey != null && apiKey.Equals(_apiKey))
            {
                await _next(context);
                return;
            }
            else
            {
                var authDb = _context.Auths.FirstOrDefaultAsync(x => x.Token.Equals(apiKey));
                if (authDb is not null)
                {
                    await _next(context);
                    return;
                }
            }

            context.Response.StatusCode = 401; // Unauthorized
            await context.Response.WriteAsync("Geh weg...");
        }
    }
}
