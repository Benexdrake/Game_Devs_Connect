namespace GameDevsConnect.Backend.API.Notification.Application.Repository.V1;
public class NotificationRepository(GDCDbContext context) : INotificationRepository
{
    private readonly GDCDbContext _context = context;

    public async Task<ApiResponse> AddAsync(NotificationDTO notification, CancellationToken token)
    {
        try
        {
            notification.Id = Guid.NewGuid().ToString();

            var validator = new Validator(_context, ValidationMode.Add);

            var valid = await validator.ValidateAsync(notification, token);

            if (!valid.IsValid)
            {
                var errors = new List<string>();

                foreach (var error in valid.Errors)
                    errors.Add(error.ErrorMessage);

                Log.Error(Message.VALIDATIONERROR(notification.Id));
                return new ApiResponse(Message.VALIDATIONERROR(notification.Id), false, [.. errors]);
            }

            await _context.Notifications.AddAsync(notification, token);
            await _context.SaveChangesAsync();

            Log.Information(Message.ADD(notification.Id));
            return new ApiResponse(Message.ADD(notification.Id), true);
        }
        catch (Exception ex)
        {
            Log.Error(ex.Message);
            return new ApiResponse(ex.Message, false);
        }
    }

    public async Task<ApiResponse> DeleteAsync(string notificationId, CancellationToken token)
    {
        try
        {
            var notifivationDb = await _context.Notifications.FirstOrDefaultAsync(x => x.Id.Equals(notificationId), token);

            if (notifivationDb is null)
            {
                Log.Error(Message.NOTFOUND(notificationId));
                return new ApiResponse(Message.NOTFOUND(notificationId), false);
            }

            _context.Notifications.Remove(notifivationDb);
            await _context.SaveChangesAsync();

            Log.Information(Message.DELETE(notificationId));
            return new ApiResponse(Message.DELETE(notificationId), true);
        }
        catch (Exception ex)
        {
            Log.Error(ex.Message);
            return new ApiResponse(ex.Message, false);
        }
    }

    public async Task<GetByIdResponse> GetByIdAsync(string id, CancellationToken token)
    {
        try
        {
            var notification = await _context.Notifications.FirstOrDefaultAsync(x => x.Id.Equals(id), token);

            if (notification is null)
            {
                Log.Error(Message.NOTFOUND(id));
                return new GetByIdResponse(Message.NOTFOUND(id), false, null!);
            }

            return new GetByIdResponse(null!, true, notification);
        }
        catch (Exception ex)
        {
            Log.Error(ex.Message);
            return new GetByIdResponse(ex.Message, false, null!);
        }
    }

    public async Task<GetIdsByUserIdResponse> GetIdsByUserIdAsync(string userId, CancellationToken token)
    {
        try
        {
            var notificationIds = await _context.Notifications
                                                  .Where(x => x.OwnerId!.Equals(userId))
                                                  .OrderByDescending(n => n.Created)
                                                  .Select(x => x.Id)
                                                  .ToArrayAsync(token);

            return new GetIdsByUserIdResponse(null!, true, notificationIds);
        }
        catch (Exception ex)
        {
            Log.Error(ex.Message);
            return new GetIdsByUserIdResponse(ex.Message, false, null!);
        }
    }

    public async Task<GetUnseenCountResponse> GetUnseenCountAsync(string userId, CancellationToken token)
    {
        try
        {
            var count = (await _context.Notifications.Where(x => !x.Seen.Equals("")).ToListAsync(token)).Count;
            return new GetUnseenCountResponse("", true, count);
        }
        catch (Exception ex)
        {
            Log.Error(ex.Message);
            return new GetUnseenCountResponse(ex.Message, false, 0);
        }

    }

    public async Task<ApiResponse> UpdateAsync(string notificationId, CancellationToken token)
    {
        try
        {
            var notificationDb = await _context.Notifications.AsNoTracking().FirstOrDefaultAsync(x => x.Id.Equals(notificationId), token);

            if (notificationDb is null)
            {
                Log.Error(Message.NOTFOUND(notificationId));
                return new ApiResponse(Message.NOTFOUND(notificationId), false);
            }

            if (notificationDb.Seen == false)
            {
                notificationDb.Seen = true;
                _context.Notifications.Update(notificationDb);
                await _context.SaveChangesAsync();
            }

            Log.Information(Message.UPDATE(notificationId));
            return new ApiResponse(Message.UPDATE(notificationId), true);
        }
        catch (Exception ex)
        {
            Log.Error(ex.Message);
            return new ApiResponse(ex.Message, false);
        }
    }
}
