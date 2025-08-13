namespace GameDevsConnect.Backend.API.User.Application.Repository.V1;

public class UserRepository(GDCDbContext context) : IUserRepository
{
    private readonly GDCDbContext _context = context;

    public async Task<GetUserIdResponse> AddAsync(UserDTO user, CancellationToken token = default)
    {
        try
        {
            var errors = await new Validation().ValidateUser(_context, ValidationMode.Add, user, token);
            if (errors.Length > 0)
                return new GetUserIdResponse(Message.VALIDATIONERROR(user.LoginId), false, string.Empty, errors);

            user.Id = Guid.NewGuid().ToString();

            await _context.Users.AddAsync(user, token);
            await _context.Profiles.AddAsync(new ProfileDTO(Guid.NewGuid().ToString(), user.Id), token);
            await _context.SaveChangesAsync(token);

            Log.Information(Message.ADD(user.Id));
            return new GetUserIdResponse(Message.ADD(user.Id), true, user.Id);
        }
        catch (Exception ex)
        {
            Log.Error(ex.Message);
            return new GetUserIdResponse("", false, string.Empty, [ex.Message]);
        }
    }

    public async Task<ApiResponse> DeleteAsync(string id, CancellationToken token = default)
    {
        try
        {
            var dbUser = await _context.Users.FirstOrDefaultAsync(x => x.Id == id, token);
            if (dbUser is null)
            {
                Log.Error(Message.NOTFOUND(id));
                return new ApiResponse(Message.NOTFOUND(id), false);
            }
            _context.Users.Remove(dbUser);
            await _context.SaveChangesAsync(token);
            Log.Information(Message.DELETE(id));
            return new ApiResponse(Message.DELETE(id), true);
        }
        catch (Exception ex)
        {
            Log.Error(ex.Message);
            return new ApiResponse("", false, [ex.Message]);
        }
    }

    public async Task<GetUserByIdResponse> GetAsync(string id, CancellationToken token = default)
    {
        try
        {
            var user = await _context.Users.FirstOrDefaultAsync(x => x.Id == id, token);
            if (user is null)
            {
                Log.Error(Message.NOTFOUND(id));
                return new GetUserByIdResponse(Message.NOTFOUND(id), false, null!);
            }
            
            return new GetUserByIdResponse("", true, user);
        }
        catch (Exception ex)
        {
            Log.Error(ex.Message);
            return new GetUserByIdResponse("", false, null!);
        }
    }

    public async Task<ApiResponse> GetExistAsync(string id, CancellationToken token = default)
    {
        try
        {
            var exist = await _context.Users.AnyAsync(x => x.Id.Equals(id), token);
            return new ApiResponse("", exist);
        }
        catch (Exception ex)
        {
            Log.Error(ex.Message);
            return new ApiResponse("", false, [ex.Message]);
        }
    }

    public async Task<GetUserIdsResponse> GetFollowerAsync(string id, CancellationToken token = default)
    {
        try
        {
            var ids = await _context.UserFollows.Where(x => x.UserId!.Equals(id)).Select(x => x.FollowId).ToArrayAsync(token) ?? [];

            return new GetUserIdsResponse("", true, ids!);
        }
        catch (Exception ex)
        {
            Log.Error(ex.Message);
            return new GetUserIdsResponse("", false, []);
        }
    }

    public async Task<GetUserIdsResponse> GetFollowingAsync(string id, CancellationToken token = default)
    {
        try
        {
            var ids = await _context.UserFollows.Where(x => x.FollowId!.Equals(id)).Select(x => x.UserId).ToArrayAsync(token) ?? [];

            return new GetUserIdsResponse("", true, ids!);
        }
        catch (Exception ex)
        {
            Log.Error(ex.Message);
            return new GetUserIdsResponse("", false, []);
        }
    }

    public async Task<GetCountResponse> GetFollowerCountAsync(string id, CancellationToken token = default)
    {
        try
        {
            var count = await _context.UserFollows.Where(x => x.UserId!.Equals(id)).CountAsync(token);

            return new GetCountResponse("", true, count);
        }
        catch (Exception ex)
        {
            Log.Error(ex.Message);
            return new GetCountResponse("", true, 0, [ex.Message]);
        }
    }

    public async Task<GetCountResponse> GetFollowingCountAsync(string id, CancellationToken token = default)
    {
        try
        {
            var count = await _context.UserFollows.Where(x => x.FollowId!.Equals(id)).CountAsync(token);

            return new GetCountResponse("", true, count);
        }
        catch (Exception ex)
        {
            Log.Error(ex.Message);
            return new GetCountResponse("", true, 0, [ex.Message]);
        }
    }

    public async Task<GetUserIdsResponse> GetIdsAsync(CancellationToken token = default)
    {
        try
        {
            var userIds = await _context.Users.Select(x => x.Id).ToArrayAsync(token);
            return new GetUserIdsResponse("", true, userIds);
        }
        catch (Exception ex)
        {
            Log.Error(ex.Message);
            return new GetUserIdsResponse("", false, [], [ex.Message]);
        }
    }

    public async Task<GetUserIdsResponse> GetIdsByProjectIdAsync(string id, CancellationToken token = default)
    {
        try
        {
            var ids = await _context.ProjectFollwers.Where(x => x.ProjectId!.Equals(id)).Select(x => x.UserId).ToArrayAsync(token) ?? [];

            return new GetUserIdsResponse("", true, ids!);
        }
        catch (Exception ex)
        {
            Log.Error(ex.Message);
            return new GetUserIdsResponse("", false, [], [ex.Message]);
        }
    }

    public async Task<ApiResponse> UpdateAsync(UserDTO user, CancellationToken token = default)
    {
        try
        {
            var errors = await new Validation().ValidateUser(_context, ValidationMode.Update, user, token);
            if (errors.Length > 0)
                return new ApiResponse(Message.VALIDATIONERROR(user.Id), false, errors);

            _context.Users.Update(user);
            await _context.SaveChangesAsync(token);
            Log.Information(Message.UPDATE(user.Id));
            return new ApiResponse(Message.UPDATE(user.Id), true);
        }
        catch (Exception ex)
        {
            Log.Error(ex.Message);
            return new ApiResponse("", false, [ex.Message]);
        }
    }
}
