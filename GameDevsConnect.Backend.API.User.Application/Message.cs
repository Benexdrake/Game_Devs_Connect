namespace GameDevsConnect.Backend.API.User.Application;

internal static class Message
{
    internal static string Id { get; set; } = String.Empty;

    internal static string NOTFOUND = $"User: {Id} not found";
    internal static string EXIST = $"User: {Id} already exist";
    internal static string ADD = $"User: {Id} Added";
    internal static string UPDATE = $"User: {Id} Updated";
    internal static string DELETE = $"User: {Id} Deleted";
}
