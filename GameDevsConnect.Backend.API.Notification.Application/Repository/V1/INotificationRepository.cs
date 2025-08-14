namespace GameDevsConnect.Backend.API.Notification.Application.Repository.V1;
public interface INotificationRepository
{
    Task<GetByIdResponse> GetByIdAsync(string id, CancellationToken token);
    Task<GetIdsByUserIdResponse> GetIdsByUserIdAsync(string userId, CancellationToken token);
    Task<ApiResponse> AddAsync(NotificationDTO notification, CancellationToken token);
    Task<ApiResponse> UpdateAsync(string notificationId, CancellationToken token);
    Task<GetUnseenCountResponse> GetUnseenCountAsync(string userId, CancellationToken token);
    Task<ApiResponse> DeleteAsync(string notificationId, CancellationToken token);
}
