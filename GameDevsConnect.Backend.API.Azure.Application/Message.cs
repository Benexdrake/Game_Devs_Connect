namespace GameDevsConnect.Backend.API.Azure.Application;

internal static class Message
{
    internal static string Id { get; set; } = String.Empty;

    internal static string NOTFOUND = $"Comment: {Id} not found";
    internal static string UPLOAD = $"File: {Id} Uploaded";
    internal static string UPDATE = $"File: {Id} Updated";
    internal static string DELETE = $"File: {Id} Deleted";
}
