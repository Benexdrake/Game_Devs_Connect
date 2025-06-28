namespace GameDevsConnect.Backend.API.Tag.Application;

internal static class Message
{
    internal static string NOTFOUND(string id) => $"Tag: {id} not found";
    internal static string EXIST(string id) => $"Tag: {id} already exist";
    internal static string ADD(string id) => $"Tag: {id} Added";
    internal static string UPDATE(string id) => $"Tag: {id} Updated";
    internal static string DELETE(string id) => $"Tag: {id} Deleted";
    internal static string VALIDATIONERROR(string id) => $"Tag: '{id}' ValidationError";
}
