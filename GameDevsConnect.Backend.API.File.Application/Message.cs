namespace GameDevsConnect.Backend.API.File.Application;

internal static class Message
{
    internal static string Id { get; set; } = String.Empty;

    internal static string NOTFOUND = $"File: {Id} not found";
    internal static string EXIST = $"File: {Id} already exist";
    internal static string ADD = $"File: {Id} Added";
    internal static string UPDATE = $"File: {Id} Updated";
    internal static string DELETE = $"File: {Id} Deleted";
}
