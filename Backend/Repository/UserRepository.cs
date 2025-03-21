namespace Backend.Repository;

public class UserRepository(GdcContext context) : IUserRepository
{
    private readonly GdcContext _context = context;
    public async Task<APIResponse> AddUserAsync(User user)
    {
        try
        {
            var dbUser = await _context.Users.FirstOrDefaultAsync(x => x.Id == user.Id);

            if (dbUser is not null) return new APIResponse("User exists in DB", false, new { });

            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();

            return new APIResponse("User was saved in DB", true, new { });
        }
        catch (Exception ex)
        {
            Log.Error(ex.Message);
            return new APIResponse(ex.Message, false, new { });
        }
    }

    public async Task<APIResponse> DeleteUserAsync(string id)
    {
        try
        {
            var dbUser = await _context.Users.FirstOrDefaultAsync(x => x.Id == id);

            if (dbUser is null) return new APIResponse("User dont exist", false, new { });

            _context.Users.Remove(dbUser);

            await _context.SaveChangesAsync();
            
            return new APIResponse("User got deleted", true, new { });
        }
        catch (Exception ex)
        {
            Log.Error(ex.Message);
            return new APIResponse(ex.Message, false, new { });
        }
    }

    public async Task<APIResponse> GetUserAsync(string id)
    {
        var user = await _context.Users.FirstOrDefaultAsync(x => x.Id == id);

        if (user is null) return new APIResponse("User dont exist",false, new { });

        return new APIResponse("", true, user);
    }

    public async Task<APIResponse> GetUsersAsync()
    {
        var userIds = await _context.Users.Select(x => x.Id).ToListAsync();

        return new APIResponse("",true, userIds);
    }

    public async Task<APIResponse> UpdateUserAsync(User user)
    {
        try
        {
            var dbUser = await _context.Users.AsNoTracking().FirstOrDefaultAsync(x => x.Id == user.Id);

            if (dbUser is null) return new APIResponse("", false, new { });

            _context.Users.Update(user);
            await _context.SaveChangesAsync();

            return new APIResponse("User got updated", true, new { });
        }
        catch (Exception ex)
        {
            Log.Error(ex.Message);
            return new APIResponse(ex.Message, false, new { });
        }
    }
}
