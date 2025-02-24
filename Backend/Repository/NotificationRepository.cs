namespace Backend.Repository;
public class NotificationRepository(GdcContext context) : INotificationRepository
{
    private readonly GdcContext _context = context;

    public async Task<APIResponse> AddNotification(Notification notification)
    {
        try
        {
            var notifivationDb = await _context.Notifications.FirstOrDefaultAsync(x => x.Id.Equals(notification.Id));
            if (notifivationDb is not null) return new APIResponse("Notification already exist", false, new { });

            var request = await _context.Requests.FirstOrDefaultAsync(x => x.Id == notification.RequestId);
            if (request is null) return new APIResponse("Cant save Notification, missing request", false, new { });
            notification.OwnerId = request.OwnerId;
            notification.Created = string.Format("{0:yyyy-MM-ddTHH:mm:ss.fffZ}", DateTime.UtcNow);

            _context.Notifications.Add(notification);
            await _context.SaveChangesAsync();

            return new APIResponse("Notification saved in DB", true, new {});
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return new APIResponse(ex.Message, false, new { });
        }
    }

    public async Task<APIResponse> GetNotificationById(string id)
    {
        try
        {
            var notification = await _context.Notifications.FirstOrDefaultAsync(x => x.Id == id);

            if (notification is null) return new APIResponse("Notification dont exist",false, new { });

            return new APIResponse("", true, notification);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return new APIResponse(ex.Message, false, new { });
        }
    }

    public async Task<APIResponse> GetNotificationIdsByUserID(string userId)
    {
        try
        {
            var notificationIds = await _context.Notifications.Where(x => x.OwnerId.Equals(userId)).OrderByDescending(n => n.Created).Select(x => x.Id).ToListAsync();
            return new APIResponse("", true, notificationIds);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return new APIResponse(ex.Message, false, new { });
        }
    }

    public async Task<APIResponse> GetUnseenNotificationsCount(string userId)
    {
        var count = (await _context.Notifications.Where(x => !x.Seen.Equals("")).ToListAsync()).Count;
        return new APIResponse("", true, count);
    }

    public async Task<APIResponse> UpdateNotification(string notificationId)
    {
        try
        {
            var notificationDb = await _context.Notifications.AsNoTracking().FirstOrDefaultAsync(x => x.Id.Equals(notificationId));
            if (notificationDb is null) return new APIResponse("Notification dont exist exist", false, new { });

            if (notificationDb.Seen.Equals(""))
            {
                notificationDb.Seen = string.Format("{0:yyyy-MM-ddTHH:mm:ss.fffZ}", DateTime.UtcNow);
                _context.Notifications.Update(notificationDb);
                await _context.SaveChangesAsync();
            }

            return new APIResponse("Notification Updated", true, new { });
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return new APIResponse(ex.Message, false, new { });
        }
    }
}
