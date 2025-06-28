namespace GameDevsConnect.Backend.API.Notification.Application;

internal static class Message
{
    internal static string NOTFOUND(string id) => $"Notification: {id} not found";
    internal static string EXIST(string id) => $"Notification: {id} already exist";
    internal static string ADD(string id) => $"Notification: {id} Added";
    internal static string UPDATE(string id) => $"Notification: {id} Updated";
    internal static string DELETE(string id) => $"Notification: {id} Deleted";
    internal static string VALIDATIONERROR(string id) => $"Notification: '{id}' ValidationError";
}
