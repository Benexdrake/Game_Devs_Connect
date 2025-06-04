namespace GameDevsConnect.Backend.API.Notification.Application.Repository.V1;
public interface INotificationRepository
{
    Task<GetByIdResponse> GetByIdAsync(string id);
    Task<GetIdsByUserIdResponse> GetIdsByUserIdAsync(string userId);
    Task<AddUpdateDeleteResponse> AddAsync(NotificationModel notification);
    Task<AddUpdateDeleteResponse> UpdateAsync(string notificationId);
    Task<GetUnseenCountResponse> GetUnseenCountAsync(string userId);
    Task<AddUpdateDeleteResponse> DeleteAsync(string notificationId);
}
