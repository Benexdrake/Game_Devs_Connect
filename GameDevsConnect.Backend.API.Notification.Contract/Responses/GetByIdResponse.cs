namespace GameDevsConnect.Backend.API.Notification.Contract.Responses;

public class GetByIdResponse(string message, bool status, NotificationDTO notification, string[] errors = default!)
{
    public ApiResponse Response { get; set; } = new ApiResponse(message, status, errors);
    public NotificationDTO Notification { get; set; } = notification;
}
