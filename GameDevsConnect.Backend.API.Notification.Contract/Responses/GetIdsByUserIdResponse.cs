namespace GameDevsConnect.Backend.API.Notification.Contract.Responses;

public class GetIdsByUserIdResponse(string message, bool status, string[] ids)
{
    public string Message { get; set; } = message;
    public bool Status { get; set; } = status;
    public string[] Ids { get; set; } = ids;
}
