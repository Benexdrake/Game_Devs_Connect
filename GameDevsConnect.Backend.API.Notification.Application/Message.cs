namespace GameDevsConnect.Backend.API.Notification.Application;

internal static class Message
{
    internal static string Id { get; set; } = String.Empty;

    internal static string NOTFOUND = $"Notification: {Id} not found";
    internal static string EXIST = $"Notification: {Id} already exist";
    internal static string ADD = $"Notification: {Id} Added";
    internal static string UPDATE = $"Notification: {Id} Updated";
    internal static string DELETE = $"Notification: {Id} Deleted";
}
