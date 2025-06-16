namespace GameDevsConnect.Backend.API.Notification.Contract.Responses;

public class GetUnseenCountResponse(string message, bool status, int count) : ApiResponse(message, status)
{
    public int Count { get; set; } = count;
}
