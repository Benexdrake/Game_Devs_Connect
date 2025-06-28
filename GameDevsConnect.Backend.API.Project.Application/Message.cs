namespace GameDevsConnect.Backend.API.Project.Application;

internal static class Message
{
    internal static string NOTFOUND(string id) => $"Profile: {id} not found";
    internal static string EXIST(string id) => $"Project: {id} already exist";
    internal static string ADD(string id) => $"Profile: {id} Added";
    internal static string UPDATE(string id) => $"Profile: {id} Updated";
    internal static string DELETE(string id) => $"Profile: {id} Deleted";
    internal static string VALIDATIONERROR(string id) => $"Project: '{id}' ValidationError";
}
