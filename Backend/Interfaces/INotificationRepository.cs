namespace Backend.Interfaces;
public interface INotificationRepository
{
    Task<APIResponse> GetNotificationById(string id);
    Task<APIResponse> GetNotificationIdsByUserID(string userId);
    Task<APIResponse> AddNotification(Notification notification);
    Task<APIResponse> UpdateNotification(Notification notification);
    Task<APIResponse> GetUnseenNotificationsCount(string userId);
}
