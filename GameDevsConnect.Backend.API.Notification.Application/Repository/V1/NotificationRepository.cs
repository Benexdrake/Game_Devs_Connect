namespace GameDevsConnect.Backend.API.Notification.Application.Repository.V1;
public class NotificationRepository(GDCDbContext context) : INotificationRepository
{
    private readonly GDCDbContext _context = context;

    public async Task<ApiResponse> AddAsync(NotificationModel notification)
    {
        try
        {
            Message.Id = notification.Id;
            
            var notifivationDb = await _context.Notifications.FirstOrDefaultAsync(x => x.Id.Equals(notification.Id));

            if (notifivationDb is not null)
            {
                Log.Error(Message.EXIST);
                return new ApiResponse(Message.EXIST, false);
            }

            _context.Notifications.Add(notification);
            await _context.SaveChangesAsync();

            Log.Information(Message.ADD);
            return new ApiResponse(Message.ADD, true);
        }
        catch (Exception ex)
        {
            Log.Error(ex.Message);
            return new ApiResponse(ex.Message, false);
        }
    }

    public async Task<ApiResponse> DeleteAsync(string notificationId)
    {
        try
        {
            Message.Id = notificationId;

            var notifivationDb = await _context.Notifications.FirstOrDefaultAsync(x => x.Id.Equals(notificationId));

            if (notifivationDb is null)
            {
                Log.Error(Message.NOTFOUND);
                return new ApiResponse(Message.NOTFOUND, false);
            }

            _context.Notifications.Remove(notifivationDb);
            await _context.SaveChangesAsync();

            Log.Information(Message.DELETE);
            return new ApiResponse(Message.DELETE, true);
        }
        catch (Exception ex)
        {
            Log.Error(ex.Message);
            return new ApiResponse(ex.Message, false);
        }
    }

    public async Task<GetByIdResponse> GetByIdAsync(string id)
    {
        try
        {
            Message.Id = id;
            var notification = await _context.Notifications.FirstOrDefaultAsync(x => x.Id.Equals(id));

            if (notification is null)
            {
                Log.Error(Message.NOTFOUND);
                return new GetByIdResponse(Message.NOTFOUND, false, null!);
            }

            return new GetByIdResponse(null!, true, notification);
        }
        catch (Exception ex)
        {
            Log.Error(ex.Message);
            return new GetByIdResponse(ex.Message, false, null!);
        }
    }

    public async Task<GetIdsByUserIdResponse> GetIdsByUserIdAsync(string userId)
    {
        try
        {
            var notificationIds = await _context.Notifications.Where(x => x.OwnerId.Equals(userId)).OrderByDescending(n => n.Created).Select(x => x.Id).ToArrayAsync();

            return new GetIdsByUserIdResponse(null!, true, notificationIds);
        }
        catch (Exception ex)
        {
            Log.Error(ex.Message);
            return new GetIdsByUserIdResponse(ex.Message, false, null!);
        }
    }

    public async Task<GetUnseenCountResponse> GetUnseenCountAsync(string userId)
    {
        try
        {
            var count = (await _context.Notifications.Where(x => !x.Seen.Equals("")).ToListAsync()).Count;
            return new GetUnseenCountResponse("", true, count);
        }
        catch (Exception ex)
        {
            Log.Error(ex.Message);
            return new GetUnseenCountResponse(ex.Message, false, 0);
        }

    }

    public async Task<ApiResponse> UpdateAsync(string notificationId)
    {
        try
        {
            Message.Id = notificationId;

            var notificationDb = await _context.Notifications.AsNoTracking().FirstOrDefaultAsync(x => x.Id.Equals(notificationId));

            if (notificationDb is null)
            {
                Log.Error(Message.NOTFOUND);
                return new ApiResponse(Message.NOTFOUND, false);
            }

            if (notificationDb.Seen == false)
            {
                notificationDb.Seen = true;
                _context.Notifications.Update(notificationDb);
                await _context.SaveChangesAsync();
            }

            Log.Information(Message.UPDATE);
            return new ApiResponse(Message.UPDATE, true);
        }
        catch (Exception ex)
        {
            Log.Error(ex.Message);
            return new ApiResponse(ex.Message, false);
        }
    }
}
