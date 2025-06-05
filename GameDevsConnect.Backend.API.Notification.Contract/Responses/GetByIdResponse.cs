using GameDevsConnect.Backend.Shared.Models;
using GameDevsConnect.Backend.Shared.Responses;

namespace GameDevsConnect.Backend.API.Notification.Contract.Responses;

public class GetByIdResponse(string message, bool status, NotificationModel notification) : ApiResponse(message, status)
{
    public NotificationModel Notification { get; set; } = notification;
}
