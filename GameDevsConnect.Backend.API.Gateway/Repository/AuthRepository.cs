using GameDevsConnect.Backend.API.Gateway.Repository;
using GameDevsConnect.Backend.Shared.Data;
using GameDevsConnect.Backend.Shared.Models;
using Microsoft.EntityFrameworkCore;
using Serilog;

namespace GameDevsConnect.Backend.API.Auth.Repository;

public class AuthRepository(AuthDbContext context) : IAuthRepository
{
    public async Task UpsertAsync(AuthModel auth)
    {
        try
        {
            var authDb = await context.Auths.FirstOrDefaultAsync(x => x.UserId.Equals(auth.UserId));

            if (authDb is null)
            {
                context.Auths.Add(auth);
                await context.SaveChangesAsync();
                return;
            }

            context.Auths.Update(auth);
            await context.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            Log.Error(ex.Message);
        }
    }

    public async Task DeleteAsync(AuthModel auth)
    {
        try
        {
            var authDb = await context.Auths.FirstOrDefaultAsync(x => x.UserId.Equals(auth.UserId));

            if(authDb is not null)
            {
                context.Auths.Remove(auth);
                await context.SaveChangesAsync();
            }
        }
        catch (Exception ex)
        {
            Log.Error(ex.Message);
        }
    }

    public async Task<bool> AuthenticateAsync(AuthModel auth)
    {
        try
        {
            var authDb = await context.Auths.FirstOrDefaultAsync(x => x.UserId.Equals(auth.UserId));
            if (authDb is null)
                return false;

            var expiresAt = DateTimeOffset.FromUnixTimeMilliseconds(auth.Expires);

            if(expiresAt.UtcDateTime <= DateTime.UtcNow)
            {
                context.Auths.Remove(auth);
                await context.SaveChangesAsync();
                return false;
            }

            if (auth.Token == authDb.Token)
                return true;

            return false;
        }
        catch (Exception ex)
        {
            Log.Error(ex.Message);
            return false;
        }
    }
}
