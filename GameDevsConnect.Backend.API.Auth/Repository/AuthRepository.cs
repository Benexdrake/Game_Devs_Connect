namespace GameDevsConnect.Backend.API.Auth.Repository;
public class AuthRepository(AuthDBContext context) : IAuthRepository
{
    private readonly AuthDBContext _context = context;

    public async Task<APIResponse> Add(AuthModel auth)
    {
        try
        {
            var authDb = _context.Auths.FirstOrDefault(x => x.UserId.Equals(auth.UserId));

            if (authDb is not null) return new APIResponse("Auth exist in DB",false,new {});

            _context.Auths.Add(auth);
            await _context.SaveChangesAsync();

            return new APIResponse("Auth Saved",true,new {});

        }
        catch (Exception ex)
        {
            Log.Error(ex.Message);
            return new APIResponse(ex.Message, true, new { });
        }
    }

    public async Task<APIResponse> Delete(string userId)
    {
        try
        {
            var authDb = _context.Auths.FirstOrDefault(x => x.UserId.Equals(userId));

            if (authDb is null) return new APIResponse("Auth dont exist in DB", false, new { });

            _context.Auths.Remove(authDb);
            await _context.SaveChangesAsync();

            return new APIResponse("Auth Deleted", true, new { });
        }
        catch (Exception ex)
        {
            Log.Error(ex.Message);
            return new APIResponse(ex.Message, true, new { });
        }
    }

    public async Task<APIResponse> Get(string userId)
    {
        try
        {
            var authDb = await _context.Auths.FirstOrDefaultAsync(x => x.UserId.Equals(userId));

            if (authDb is null) return new APIResponse("Auth dont exist in DB", false, new { });

            return new APIResponse("", true, authDb);
        }
        catch (Exception ex)
        {
            Log.Error(ex.Message);
            return new APIResponse(ex.Message, true, new { });
        }
    }

    public async Task<APIResponse> Update(AuthModel auth)
    {
        try
        {
            var authDb = _context.Auths.AsNoTracking().FirstOrDefault(x => x.UserId.Equals(auth.UserId));

            if (authDb is null) return new APIResponse("Auth dont exist in DB", false, new { });

            _context.Auths.Update(auth);
            await _context.SaveChangesAsync();

            return new APIResponse("Auth Updated", true, new {});

        }
        catch (Exception ex)
        {
            Log.Error(ex.Message);
            return new APIResponse(ex.Message, true, new { });
        }
    }
}
