namespace GameDevsConnect.Backend.API.Notification.Repository;
public class NotificationRepository(NotificationDBContext context) : INotificationRepository
{
    private readonly NotificationDBContext _context = context;

    public async Task<APIResponse> AddAsync(NotificationModel notification)
    {
        try
        {
            var notifivationDb = await _context.Notifications.FirstOrDefaultAsync(x => x.Id.Equals(notification.Id));
            if (notifivationDb is not null) return new APIResponse("Notification already exist", false, new { });

            _context.Notifications.Add(notification);
            await _context.SaveChangesAsync();

            return new APIResponse("Notification saved in DB", true, new {});
        }
        catch (Exception ex)
        {
            Log.Error(ex.Message);
            return new APIResponse(ex.Message, false, new { });
        }
    }

    public async Task<APIResponse> DeleteAsync(string notificationId)
    {
        try
        {
            var notifivationDb = await _context.Notifications.FirstOrDefaultAsync(x => x.Id.Equals(notificationId));
            if (notifivationDb is null) return new APIResponse("Notification dont exist", false, new { });

            _context.Notifications.Remove(notifivationDb);
            await _context.SaveChangesAsync();

            return new APIResponse("Notification removed from DB", true, new { });
        }
        catch (Exception ex)
        {
            Log.Error(ex.Message);
            return new APIResponse(ex.Message, false, new { });
        }
    }

    public async Task<APIResponse> GetByIdAsync(string id)
    {
        try
        {
            var notification = await _context.Notifications.FirstOrDefaultAsync(x => x.Id == id);

            if (notification is null) return new APIResponse("Notification dont exist",false, new { });

            return new APIResponse("", true, notification);
        }
        catch (Exception ex)
        {
            Log.Error(ex.Message);
            return new APIResponse(ex.Message, false, new { });
        }
    }

    public async Task<APIResponse> GetIdsByUserIdAsync(string userId)
    {
        try
        {
            var notificationIds = await _context.Notifications.Where(x => x.OwnerId.Equals(userId)).OrderByDescending(n => n.Created).Select(x => x.Id).ToListAsync();
            return new APIResponse("", true, notificationIds);
        }
        catch (Exception ex)
        {
            Log.Error(ex.Message);
            return new APIResponse(ex.Message, false, new { });
        }
    }

    public async Task<APIResponse> GetUnseenCountAsync(string userId)
    {
        var count = (await _context.Notifications.Where(x => !x.Seen.Equals("")).ToListAsync()).Count;
        return new APIResponse("", true, count);
    }

    public async Task<APIResponse> UpdateAsync(string notificationId)
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
            Log.Error(ex.Message);
            return new APIResponse(ex.Message, false, new { });
        }
    }
}
