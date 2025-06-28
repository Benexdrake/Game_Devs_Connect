namespace GameDevsConnect.Backend.API.Notification.Application.Repository.V1;
public interface INotificationRepository
{
    Task<GetByIdResponse> GetByIdAsync(string id);
    Task<GetIdsByUserIdResponse> GetIdsByUserIdAsync(string userId);
    Task<ApiResponse> AddAsync(NotificationDTO notification);
    Task<ApiResponse> UpdateAsync(string notificationId);
    Task<GetUnseenCountResponse> GetUnseenCountAsync(string userId);
    Task<ApiResponse> DeleteAsync(string notificationId);
}
