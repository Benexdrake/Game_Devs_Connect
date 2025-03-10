namespace Backend.Interfaces;
public interface INotificationRepository
{
    Task<APIResponse> GetNotificationById(string id);
    Task<APIResponse> GetNotificationIdsByUserID(string userId);
    Task<APIResponse> AddNotification(Notification notification);
    Task<APIResponse> UpdateNotification(string notificationId);
    Task<APIResponse> GetUnseenNotificationsCount(string userId);
    Task<APIResponse> DeleteNotification(string notificationId);
}
