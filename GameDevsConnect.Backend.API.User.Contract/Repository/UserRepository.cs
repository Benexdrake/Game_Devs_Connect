namespace GameDevsConnect.Backend.API.User.Contract.Repository;

public class UserRepository(GDCDbContext context) : IUserRepository
{
    private readonly GDCDbContext _context = context;
    public async Task<bool> AddAsync(UserModel user)
    {
        try
        {
            var dbUser = await _context.Users.FirstOrDefaultAsync(x => x.Id == user.Id);

            if (dbUser is not null)
            {
                Log.Information($"User with ID: {dbUser.Id} exists already");
                return false;
            }

            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();

            return true;
        }
        catch (Exception ex)
        {
            Log.Error(ex.Message);
            return false;
        }
    }

    public async Task<bool> DeleteAsync(string id)
    {
        try
        {
            var dbUser = await _context.Users.FirstOrDefaultAsync(x => x.Id == id);

            if (dbUser is null)
            {
                Log.Information($"User with ID: {id} dont exist");
                return false;
            }

            _context.Users.Remove(dbUser);

            await _context.SaveChangesAsync();
            
            return true;
        }
        catch (Exception ex)
        {
            Log.Error(ex.Message);
            return false;
        }
    }

    public async Task<UserModel> GetAsync(string id)
    {
        try
        {
            var user = await _context.Users.FirstOrDefaultAsync(x => x.Id == id);

            if (user is null)
                Log.Information($"User with ID: {id} dont exist");

            return user!;
        }
        catch (Exception ex)
        {
            Log.Error(ex.Message);
            return null!;
        }
    }

    public async Task<string[]> GetIdsAsync()
    {
        var userIds = await _context.Users.Select(x => x.Id).ToArrayAsync();

        return userIds;
    }

    public async Task<bool> UpdateAsync(UserModel user)
    {
        try
        {
            var dbUser = await _context.Users.AsNoTracking().FirstOrDefaultAsync(x => x.Id == user.Id);

            if (dbUser is null)
            {
                Log.Information($"User with ID: {user.Id} dont exist");
                return false;
            }

            _context.Users.Update(user);
            await _context.SaveChangesAsync();

            return true;
        }
        catch (Exception ex)
        {
            Log.Error(ex.Message);
            return false;
        }
    }
}
