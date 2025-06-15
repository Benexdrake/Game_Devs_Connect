namespace GameDevsConnect.Backend.API.Profile.Application.Repository.V1;

public class ProfileRepository(GDCDbContext context) : IProfileRepository
{
    private readonly GDCDbContext _context = context;

    public async Task<ApiResponse> AddAsync(ProfileModel profile)
    {
        try
        {
            Message.Id = profile.Id;
            var dbProfile = await _context.Profiles.FirstOrDefaultAsync(p => p.Id.Equals(profile.Id));

            if (dbProfile is not null)
            {
                Log.Error(Message.EXIST);
                return new ApiResponse(Message.EXIST, false);
            }

            Log.Information(Message.ADD);
            return new ApiResponse(Message.ADD, true);
        }
        catch (Exception ex)
        {
            Log.Error(ex.Message);
            return new ApiResponse(ex.Message, false);
        }
    }

    public async Task<ApiResponse> DeleteAsync(string id)
    {
        try
        {
            Message.Id = id;
            var dbProfile = await _context.Profiles.FirstOrDefaultAsync(p => p.Id.Equals(id));
            if (dbProfile is null)
            {
                Log.Error(Message.NOTFOUND);
                return new ApiResponse(Message.NOTFOUND, false);
            }

            _context.Profiles.Remove(dbProfile);
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

    public async Task<GetResponse> GetAsync(string id)
    {
        try
        {
            Message.Id = id;
            var dbProfile = await _context.Profiles.FirstOrDefaultAsync(p => p.Id.Equals(id));

            if (dbProfile is null)
            {
                Log.Error(Message.NOTFOUND);
                return new GetResponse(Message.NOTFOUND, false, null!);
            }

            return new GetResponse(null!, true, dbProfile);
        }
        catch (Exception ex)
        {
            Log.Error(ex.Message);
            return new GetResponse(ex.Message, false, null!);
        }
    }

    public async Task<GetFullResponse> GetFullAsync(string id)
    {
        try
        {
            Message.Id = id;
            var dbProfile = await _context.Profiles.FirstOrDefaultAsync(p => p.Id.Equals(id));

            if (dbProfile is null)
            {
                Log.Error(Message.NOTFOUND);
                return new GetFullResponse(Message.NOTFOUND, false, null!, null!);
            }

            var dbUser = await _context.Users.FirstOrDefaultAsync(u => u.Id.Equals(dbProfile.UserId));

            if (dbUser is null)
            {
                Message.Id = dbProfile.UserId!;
                Log.Error(Message.USERNOTFOUND);
                return new GetFullResponse(Message.USERNOTFOUND, false, null!, null!);
            }

            return new GetFullResponse("", true, null!, dbProfile);
        }
        catch (Exception ex)
        {
            Log.Error(ex.Message);
            return new GetFullResponse(ex.Message, false, null!, null!);
        }
    }

    public async Task<ApiResponse> UpdateAsync(ProfileModel profile)
    {
        try
        {
            Message.Id = profile.Id;
            var dbProfile = await _context.Profiles.FirstOrDefaultAsync(p => p.Id.Equals(profile.Id));

            if (dbProfile is null)
            {
                Log.Error(Message.NOTFOUND);
                return new ApiResponse(Message.NOTFOUND, false);
            }

            _context.Profiles.Update(profile);
            await _context.SaveChangesAsync();

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
