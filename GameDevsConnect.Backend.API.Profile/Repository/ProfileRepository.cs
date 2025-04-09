using GameDevsConnect.Backend.Shared.Data;

namespace GameDevsConnect.Backend.API.Profile.Repository;

public class ProfileRepository(GDCDbContext context) : IProfileRepository
{
    private readonly GDCDbContext _context = context;

    public async Task<APIResponse> AddAsync(ProfileModel profile)
    {
        try
        {
            var dbProfile = await _context.Profiles.FirstOrDefaultAsync(p => p.Id.Equals(profile.Id));

            if (dbProfile is not null) return new APIResponse("Profile exists already in DB", false, new { });

            return new APIResponse("Profile saved in DB", true, new { });
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
            var dbProfile = await _context.Profiles.FirstOrDefaultAsync(p => p.Id.Equals(id));
            if (dbProfile is null) return new APIResponse("Profile not found", false, new { });

            _context.Profiles.Remove(dbProfile);
            await _context.SaveChangesAsync();

            return new APIResponse("Profile Deleted", true, new { });
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
            var dbProfile = await _context.Profiles.FirstOrDefaultAsync(p => p.Id.Equals(id));

            if (dbProfile is null) return new APIResponse("Profile not found", false, new { });


            return new APIResponse("", true, dbProfile);
        }
        catch (Exception ex)
        {
            Log.Error(ex.Message);
            return new APIResponse(ex.Message, false, new { });
        }
    }

    public async Task<APIResponse> UpdateAsync(ProfileModel profile)
    {
        try
        {
            var dbProfile = await _context.Profiles.FirstOrDefaultAsync(p => p.Id.Equals(profile.Id));

            if (dbProfile is null) return new APIResponse("Profile dont exist in DB", false, new { });

            _context.Profiles.Update(profile);
            await _context.SaveChangesAsync();

            return new APIResponse("", true, new { });
        }
        catch (Exception ex)
        {
            Log.Error(ex.Message);
            return new APIResponse(ex.Message, false, new { });
        }
    }
}
