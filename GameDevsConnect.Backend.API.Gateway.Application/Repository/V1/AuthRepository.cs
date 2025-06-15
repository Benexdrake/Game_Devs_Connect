namespace GameDevsConnect.Backend.API.Gateway.Application.Repository.V1;

public class AuthRepository(AuthDbContext context) : IAuthRepository
{
    private readonly AuthDbContext _context = context;

    public async Task UpsertAsync(AuthModel auth)
    {
        try
        {
            Message.Id = auth.UserId;
            var authDb = await _context.Auth.AsNoTracking().FirstOrDefaultAsync(x => x.UserId.Equals(auth.UserId));

            if (authDb is null)
            {
                _context.Auth.Add(auth);
                await _context.SaveChangesAsync();
                Log.Information(Message.ADD);
                return;
            }

            _context.Auth.Update(auth);
            await _context.SaveChangesAsync();
            Log.Information(Message.UPDATE);
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
            Message.Id = auth.UserId;
            var authDb = await _context.Auth.AsNoTracking().FirstOrDefaultAsync(x => x.UserId.Equals(auth.UserId));

            if (authDb is null)
            {
                Log.Error(Message.NOTFOUND);
                return;
            }

            _context.Auth.Remove(auth);
            await _context.SaveChangesAsync();
            Log.Information(Message.DELETE);
        }
        catch (Exception ex)
        {
            Log.Error(ex.Message);
        }
    }

    public async Task<AuthenticateResponse> AuthenticateAsync(string token)
    {
        try
        {
            var authDb = await _context.Auth.AsNoTracking().FirstOrDefaultAsync(x => x.Token.Equals(token));

            if (authDb is null)
            {
                Message.Id = token;
                Log.Error(Message.NOTFOUND);
                return new AuthenticateResponse(Message.NOTFOUND, false);
            }

            var expirationTime = DateTimeOffset.FromUnixTimeSeconds(authDb.Expires).UtcDateTime;

            if (expirationTime < DateTime.UtcNow)
            {
                Message.Id = authDb.UserId;
                Log.Error(Message.EXPIRES);

                _context.Auth.Remove(authDb);
                await _context.SaveChangesAsync();

                return new AuthenticateResponse(Message.EXPIRES, false);
            }

            return new AuthenticateResponse(null!, true);
        }
        catch (Exception ex)
        {
            Log.Error(ex.Message);
            return new AuthenticateResponse(ex.Message, false);
        }
    }
}
