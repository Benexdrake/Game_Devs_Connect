namespace GameDevsConnect.Backend.API.User.Repository;

public class UserRepository(UserDBContext context) : IUserRepository
{
    private readonly UserDBContext _context = context;
    public async Task<APIResponse> AddAsync(UserModel user)
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

    public async Task<APIResponse> DeleteAsync(string id)
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

    public async Task<APIResponse> GetAsync(string id)
    {
        try
        {
            var user = await _context.Users.FirstOrDefaultAsync(x => x.Id == id);

            if (user is null) return new APIResponse("User dont exist", false, new { });

            return new APIResponse("", true, user);
        }
        catch (Exception ex)
        {
            Log.Error(ex.Message);
            return new APIResponse(ex.Message, false, new { });
        }
    }

    public async Task<APIResponse> GetIdsAsync()
    {
        var userIds = await _context.Users.Select(x => x.Id).ToListAsync();

        return new APIResponse("",true, userIds);
    }

    public async Task<APIResponse> UpdateAsync(UserModel user)
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
