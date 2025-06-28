namespace GameDevsConnect.Backend.API.Post.Application;

internal static class Message
{
    internal static string Id { get; set; } = String.Empty;

    internal static string NOTFOUND = $"Request: {Id} not found";
    internal static string EXIST = $"Request: {Id} already exist";
    internal static string ADD = $"Request: {Id} Added";
    internal static string UPDATE = $"Request: {Id} Updated";
    internal static string DELETE = $"Request: {Id} Deleted";
}
