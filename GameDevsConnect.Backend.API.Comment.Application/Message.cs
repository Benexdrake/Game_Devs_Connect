namespace GameDevsConnect.Backend.API.Comment.Application;

internal static class Message
{
    internal static string Id { get; set; } = String.Empty;

    internal static string NOTFOUND = $"Comment: {Id} not found";
    internal static string EXIST = $"Comment: {Id} already exist";
    internal static string ADD = $"Comment: {Id} Added";
    internal static string UPDATE = $"Comment: {Id} Updated";
    internal static string DELETE = $"Comment: {Id} Deleted";
}
