using GameDevsConnect.Backend.API.Configuration.Application.Data;
using GameDevsConnect.Backend.API.Configuration.Contract.Responses;

namespace GameDevsConnect.Backend.API.Profile.Application.Repository.V1;

public class ProfileRepository(GDCDbContext context) : IProfileRepository
{
    private readonly GDCDbContext _context = context;

    public async Task<ApiResponse> AddAsync(string userId, CancellationToken token)
    {
        try
        {
            var profile = new ProfileDTO(userId);

            Log.Information(Message.ADD(profile.Id));
            return new ApiResponse(Message.ADD(profile.Id), true);
        }
        catch (Exception ex)
        {
            Log.Error(ex.Message);
            return new ApiResponse(ex.Message, false);
        }
    }

    public async Task<ApiResponse> DeleteAsync(string id, CancellationToken token)
    {
        try
        {
            var dbProfile = await _context.Profiles.FirstOrDefaultAsync(p => p.Id.Equals(id), token);
            if (dbProfile is null)
            {
                Log.Error(Message.NOTFOUND(id));
                return new ApiResponse(Message.NOTFOUND(id), false);
            }

            _context.Profiles.Remove(dbProfile);
            await _context.SaveChangesAsync();

            Log.Information(Message.DELETE(id));
            return new ApiResponse(Message.DELETE(id), true);
        }
        catch (Exception ex)
        {
            Log.Error(ex.Message);
            return new ApiResponse(ex.Message, false);
        }
    }

    public async Task<GetResponse> GetAsync(string id, CancellationToken token)
    {
        try
        {
            var dbProfile = await _context.Profiles.FirstOrDefaultAsync(p => p.Id.Equals(id), token);

            if (dbProfile is null)
            {
                Log.Error(Message.NOTFOUND(id));
                return new GetResponse(Message.NOTFOUND(id), false, null!);
            }

            return new GetResponse(null!, true, dbProfile);
        }
        catch (Exception ex)
        {
            Log.Error(ex.Message);
            return new GetResponse(ex.Message, false, null!);
        }
    }

    public async Task<GetFullResponse> GetFullAsync(string id, CancellationToken token)
    {
        try
        {
            var dbProfile = await _context.Profiles.FirstOrDefaultAsync(p => p.Id.Equals(id), token);

            if (dbProfile is null)
            {
                Log.Error(Message.NOTFOUND(id));
                return new GetFullResponse(Message.NOTFOUND(id), false, null!, null!, 0, 0);
            }

            var dbUser = await _context.Users.FirstOrDefaultAsync(u => u.Id.Equals(dbProfile.UserId), token);

            if (dbUser is null)
            {
                Log.Error(Message.USERNOTFOUND(id));
                return new GetFullResponse(Message.USERNOTFOUND(id), false, null!, null!, 0, 0);
            }

            var follower = await _context.UserFollows.Where(x => x.UserId!.Equals(id)).CountAsync(token);
            var following = await _context.UserFollows.Where(x => x.FollowId!.Equals(id)).CountAsync(token);

            return new GetFullResponse("", true, dbUser, dbProfile, follower, following);
        }
        catch (Exception ex)
        {
            Log.Error(ex.Message);
            return new GetFullResponse(ex.Message, false, null!, null!, 0, 0);
        }
    }

    public async Task<ApiResponse> UpdateAsync(ProfileDTO profile, CancellationToken token)
    {
        try
        {
            var validator = new Validator(_context, ValidationMode.Update);

            var valid = await validator.ValidateAsync(profile, token);

            if (!valid.IsValid)
            {
                var errors = new List<string>();

                foreach (var error in valid.Errors)
                    errors.Add(error.ErrorMessage);

                Log.Error(Message.VALIDATIONERROR(profile.Id));
                return new ApiResponse(Message.VALIDATIONERROR(profile.Id), false, [.. errors]);
            }

            _context.Profiles.Update(profile);
            await _context.SaveChangesAsync();

            Log.Information(Message.UPDATE(profile.Id));
            return new ApiResponse(Message.UPDATE(profile.Id), true);
        }
        catch (Exception ex)
        {
            Log.Error(ex.Message);
            return new ApiResponse(ex.Message, false);
        }
    }
}
