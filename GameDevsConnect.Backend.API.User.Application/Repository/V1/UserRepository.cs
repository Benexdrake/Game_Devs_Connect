namespace GameDevsConnect.Backend.API.User.Application.Repository.V1;

public class UserRepository(GDCDbContext context) : IUserRepository
{
    private readonly GDCDbContext _context = context;

    public async Task<string> AddAsync(UserDTO user, CancellationToken token = default)
    {
        user.Id = Guid.NewGuid().ToString();
        await _context.Users.AddAsync(user, token);
        await _context.Profiles.AddAsync(new ProfileDTO(user.Id), token);
        await _context.SaveChangesAsync(token);
        Log.Information(Message.ADD(user.Id));
        return user.Id;
    }

    public async Task<bool> DeleteAsync(string id, CancellationToken token = default)
    {
        var dbUser = await _context.Users.FirstOrDefaultAsync(x => x.Id == id, token);
        if (dbUser is null)
        {
            Log.Error(Message.NOTFOUND(id));
            return false;
        }
        _context.Users.Remove(dbUser);
        await _context.SaveChangesAsync(token);
        Log.Information(Message.DELETE(id));
        return true;
    }

    public async Task<UserDTO?> GetAsync(string id, CancellationToken token = default)
    {
        var user = await _context.Users.FirstOrDefaultAsync(x => x.Id == id, token);
        if (user is null)
            Log.Error(Message.NOTFOUND(id));
            
        return user;
    }

    public async Task<bool> GetExistAsync(string id, CancellationToken token = default)
    {
        try
        {
            return await _context.Users.AnyAsync(x => x.Id.Equals(id), token);
        }
        catch (Exception ex)
        {
            Log.Error(ex.Message);
            return false;
        }
    }

    public async Task<string[]> GetFollowerAsync(string id, CancellationToken token = default)
    {
        var ids = await _context.UserFollows.Where(x => x.UserId!.Equals(id)).Select(x => x.FollowId).ToArrayAsync(token);

        return ids!;
    }

    public async Task<string[]> GetFollowingAsync(string id, CancellationToken token = default)
    {
        var ids = await _context.UserFollows.Where(x => x.FollowId!.Equals(id)).Select(x => x.UserId).ToArrayAsync(token);

        return ids!;
    }

    public async Task<int> GetFollowerCountAsync(string id, CancellationToken token = default)
    {
        var count = await _context.UserFollows.Where(x => x.UserId!.Equals(id)).CountAsync(token);

        return count;
    }

    public async Task<int> GetFollowingCountAsync(string id, CancellationToken token = default)
    {
        var count = await _context.UserFollows.Where(x => x.FollowId!.Equals(id)).CountAsync(token);

        return count;
    }

    public async Task<string[]> GetIdsAsync(CancellationToken token = default)
    {
        var userIds = await _context.Users.Select(x => x.Id).ToArrayAsync(token);
        return userIds;
    }

    public async Task<string[]> GetIdsByProjectIdAsync(string id, CancellationToken token = default)
    {
        var ids = await _context.ProjectFollwers.Where(x => x.ProjectId!.Equals(id)).Select(x => x.UserId).ToArrayAsync(token);

        return ids!;
    }

    public async Task<bool> UpdateAsync(UserDTO user, CancellationToken token = default)
    {
        _context.Users.Update(user);
        await _context.SaveChangesAsync(token);
        Log.Information(Message.UPDATE(user.Id));
        return true;
    }
}
