namespace GameDevsConnect.Backend.API.Notification.Repository;
public interface INotificationRepository
{
    Task<APIResponse> GetByIdAsync(string id);
    Task<APIResponse> GetIdsByUserIdAsync(string userId);
    Task<APIResponse> AddAsync(NotificationModel notification);
    Task<APIResponse> UpdateAsync(string notificationId);
    Task<APIResponse> GetUnseenCountAsync(string userId);
    Task<APIResponse> DeleteAsync(string notificationId);
}
