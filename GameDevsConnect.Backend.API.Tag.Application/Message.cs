namespace GameDevsConnect.Backend.API.Tag.Application;

internal static class Message
{
    internal static string Id { get; set; } = String.Empty;

    internal static string NOTFOUND = $"Tag: {Id} not found";
    internal static string EXIST = $"Tag: {Id} already exist";
    internal static string ADD = $"Tag: {Id} Added";
    internal static string UPDATE = $"Tag: {Id} Updated";
    internal static string DELETE = $"Tag: {Id} Deleted";
}
