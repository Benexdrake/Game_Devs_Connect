using Microsoft.Extensions.Configuration;

namespace GameDevsConnect.Backend.Shared;

public static class ConfigurationHelper
{
    public static IConfiguration GetConfiguration()
    {
        var builder = new ConfigurationBuilder()
        .AddJsonFile("appsettings.aspire.json", optional: false, reloadOnChange: true);

        return builder.Build();
    }
}