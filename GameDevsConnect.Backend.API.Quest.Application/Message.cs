namespace GameDevsConnect.Backend.API.Quest.Application;

internal static class Message
{
    internal static string NOTFOUND(string id) => $"Quest: '{id}' not found";
    internal static string EXIST(string id) => $"Quest: '{id}' already exist";
    internal static string ADD(string id) => $"Quest: '{id}' Added";
    internal static string UPDATE(string id) => $"Quest: '{id}' Updated";
    internal static string DELETE(string id) => $"Quest: '{id}' Deleted";
    internal static string VALIDATIONERROR(string id) => $"Quest: '{id}' ValidationError";
}
