namespace GameDevsConnect.Backend.API.Post.Application;

internal static class Message
{
    internal static string NOTFOUND(string id) => $"Post: {id} not found";
    internal static string EXIST(string id) => $"Post: {id} already exist";
    internal static string ADD(string id) => $"Post: {id} Added";
    internal static string UPDATE(string id) => $"Post: {id} Updated";
    internal static string DELETE(string id) => $"Post: {id} Deleted";
}
