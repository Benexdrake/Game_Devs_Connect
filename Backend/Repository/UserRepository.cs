namespace Backend.Repository;

public class UserRepository(GDCDbContext context) : IUserRepository
{
    private readonly GDCDbContext _context = context;
    public async Task<bool> AddUserAsync(User user)
    {
        try
        {
            var dbUser = await _context.User.FirstOrDefaultAsync(x => x.Id == user.Id);

            if (dbUser is not null) return false;

            await _context.User.AddAsync(user);
            await _context.SaveChangesAsync();

            return true;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return false;
        }
    }

    public async Task<bool> DeleteUserAsync(string id)
    {
        try
        {
            var dbUser = await _context.User.FirstOrDefaultAsync(x => x.Id == id);

            if (dbUser is null) return false;

            _context.User.Remove(dbUser);

            await _context.SaveChangesAsync();
            
            return true;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return false;
        }
    }

    public async Task<IEnumerable<ShortUser>> GetShortUsersAsync()
    {
        return await _context.User.Select(x => new ShortUser(x.Id, x.Username)).ToListAsync();
    }

    public async Task<User> GetUserAsync(string id)
    {
        return await _context.User.FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<IEnumerable<User>> GetUsersAsync()
    {
        return await _context.User.ToListAsync();
    }

    public async Task<bool> UpdateUserAsync(User user)
    {
        try
        {
            var dbUser = await _context.User.FirstOrDefaultAsync(x => x.Id == user.Id);

            if (dbUser is null) return false;

            // Update User
            dbUser.Username = user.Username;
            dbUser.Banner = user.Banner;
            dbUser.Avatar = user.Avatar;
            dbUser.AccountType = user.AccountType;
            dbUser.Email = user.Email;
            dbUser.XUrl = user.XUrl;
            dbUser.DiscordUrl = user.DiscordUrl;
            dbUser.WebsiteUrl = user.WebsiteUrl;

            await _context.SaveChangesAsync();

            return true;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return false;
        }
    }
}
