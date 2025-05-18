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
            var authDb = await context.Auth.FirstOrDefaultAsync(x => x.UserId.Equals(auth.UserId));

            if (authDb is null)
            {
                context.Auth.Add(auth);
                await context.SaveChangesAsync();
                return;
            }

            context.Auth.Update(auth);
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
            var authDb = await context.Auth.FirstOrDefaultAsync(x => x.UserId.Equals(auth.UserId));

            if(authDb is not null)
            {
                context.Auth.Remove(auth);
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
            var authDb = await context.Auth.FirstOrDefaultAsync(x => x.UserId.Equals(auth.UserId));
            if (authDb is null)
                return false;

            var expiresAt = DateTimeOffset.FromUnixTimeMilliseconds(auth.Expires);

            //if(expiresAt.UtcDateTime <= DateTime.UtcNow)
            //{
            //    context.Auth.Remove(auth);
            //    await context.SaveChangesAsync();
            //    return false;
            //}

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

    public async Task<bool> AuthenticateAsync2(string token)
    {
        try
        {
            var authDb = await context.Auth.FirstOrDefaultAsync(x => x.Token.Equals(token));
            if (authDb is null)
                return false;

            return true;
        }
        catch (Exception ex)
        {
            Log.Error(ex.Message);
            return false;
        }
    }
}
