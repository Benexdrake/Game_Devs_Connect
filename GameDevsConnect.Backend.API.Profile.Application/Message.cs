namespace GameDevsConnect.Backend.API.Profile.Application;

internal static class Message
{
    internal static string Id { get; set; } = String.Empty;

    internal static string NOTFOUND = $"Profile: {Id} not found";
    internal static string USERNOTFOUND = $"User: {Id} not found";
    internal static string EXIST = $"Profile: {Id} already exist";
    internal static string ADD = $"Profile: {Id} Added";
    internal static string UPDATE = $"Profile: {Id} Updated";
    internal static string DELETE = $"Profile: {Id} Deleted";
}
