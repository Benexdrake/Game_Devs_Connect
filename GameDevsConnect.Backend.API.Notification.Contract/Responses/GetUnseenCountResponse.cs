namespace GameDevsConnect.Backend.API.Notification.Contract.Responses;

public class GetUnseenCountResponse(string message, bool status, int count)
{
    public string Message { get; set; } = message;
    public bool Status { get; set; } = status;
    public int Count { get; set; } = count;
}
