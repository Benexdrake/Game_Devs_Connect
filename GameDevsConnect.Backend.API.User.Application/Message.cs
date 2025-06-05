namespace GameDevsConnect.Backend.API.User.Application;

internal static class Message
{
    internal static string NOTFOUND(string id) => $"User: '{id}' not found";
    internal static string EXIST(string id) => $"User: '{id}' already exist";
    internal static string ADD(string id) => $"User: '{id}' Added";
    internal static string UPDATE(string id) => $"User: '{id}' Updated";
    internal static string DELETE(string id) => $"User: '{id}' Deleted";
    internal static string VALIDATIONERROR(string id) => $"User: '{id}' ValidationError";
}
