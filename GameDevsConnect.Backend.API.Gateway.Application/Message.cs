namespace GameDevsConnect.Backend.API.Gateway.Application;

internal static class Message
{
    internal static string NOTFOUND(string id) => $"Auth: {id} not found";
    internal static string EXPIRES(string id) => $"Auth: {id} is Expires and will be deleted";
    internal static string ADD(string id) => $"Auth: {id} Added";
    internal static string UPDATE(string id) => $"Auth: {id} Updated";
    internal static string DELETE(string id) => $"Auth: {id} Deleted";
}
