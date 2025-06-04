namespace GameDevsConnect.Backend.API.Gateway.Application;

internal static class Message
{
    internal static string Id { get; set; } = String.Empty;
    internal static string NOTFOUND = $"Auth: {Id} not found";
    internal static string EXPIRES = $"Auth: {Id} is Expires and will be deleted";
    internal static string ADD = $"Auth: {Id} Added";
    internal static string UPDATE = $"Auth: {Id} Updated";
    internal static string DELETE = $"Auth: {Id} Deleted";
}
