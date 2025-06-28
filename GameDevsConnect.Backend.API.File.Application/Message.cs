namespace GameDevsConnect.Backend.API.File.Application;

internal static class Message
{
    internal static string NOTFOUND(string id) => $"File: {id} not found";
    internal static string EXIST(string id) => $"File: {id} already exist";
    internal static string ADD(string id) => $"File: {id} Added";
    internal static string UPDATE(string id) => $"File: {id} Updated";
    internal static string DELETE(string id) => $"File: {id} Deleted";
    internal static string VALIDATIONERROR(string id) => $"File: '{id}' ValidationError";
}
