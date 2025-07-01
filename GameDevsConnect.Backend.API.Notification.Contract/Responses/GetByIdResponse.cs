using GameDevsConnect.Backend.API.Configuration.Contract.Responses;

namespace GameDevsConnect.Backend.API.Notification.Contract.Responses;

public class GetByIdResponse(string message, bool status, NotificationDTO notification) : ApiResponse(message, status)
{
    public NotificationDTO Notification { get; set; } = notification;
}
