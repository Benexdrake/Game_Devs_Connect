using GameDevsConnect.Backend.Shared.Models;

namespace GameDevsConnect.Backend.API.Notification.Contract.Responses;

public class GetByIdResponse(string message, bool status, NotificationModel notification)
{
    public string Message { get; set; } = message;
    public bool Status { get; set; } = status;
    public NotificationModel Notification { get; set; } = notification;
}
