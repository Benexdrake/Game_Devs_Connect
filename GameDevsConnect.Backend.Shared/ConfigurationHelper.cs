using Microsoft.Extensions.Configuration;
using System.Reflection;

namespace GameDevsConnect.Backend.Shared;

public static class ConfigurationHelper
{
    public static IConfiguration GetConfiguration()
    {
        var builder = new ConfigurationBuilder()
        .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

        return builder.Build();
    }
}