namespace GameDevsConnect.Backend.API.Azure.Application;

internal static class Message
{
    internal static string NOTFOUND(string id) => $"Comment: {id} not found";
    internal static string UPLOAD(string id) => $"File: {id} Uploaded";
    internal static string UPDATE(string id) => $"File: {id} Updated";
    internal static string DELETE(string id) => $"File: {id} Deleted";
}
