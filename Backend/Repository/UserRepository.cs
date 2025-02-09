namespace Backend.Repository;

public class UserRepository(GDCDbContext context) : IUserRepository
{
    private readonly GDCDbContext _context = context;
    public async Task<APIResponse> AddUserAsync(User user)
    {
        try
        {
            var dbUser = await _context.Users.FirstOrDefaultAsync(x => x.Id == user.Id);

            if (dbUser is not null) return new APIResponse("User exists in DB", false);

            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();

            return new APIResponse("User was saved in DB", true);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return new APIResponse(ex.Message, false); ;
        }
    }

    public async Task<APIResponse> DeleteUserAsync(string id)
    {
        try
        {
            var dbUser = await _context.Users.FirstOrDefaultAsync(x => x.Id == id);

            if (dbUser is null) return new APIResponse("User dont exist", false);

            _context.Users.Remove(dbUser);

            await _context.SaveChangesAsync();
            
            return new APIResponse("User got deleted", true);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return new APIResponse(ex.Message, false);
        }
    }

    public async Task<APIResponse> GetUserAsync(string id)
    {
        var user = await _context.Users.FirstOrDefaultAsync(x => x.Id == id);

        if (user is null) return new APIResponse("User dont exist",false);

        return new APIResponse("", true, user);
    }

    public async Task<IEnumerable<User>> GetUsersAsync()
    {
        return await _context.Users.ToListAsync();
    }

    public async Task<APIResponse> UpdateUserAsync(User user)
    {
        try
        {
            var dbUser = await _context.Users.FirstOrDefaultAsync(x => x.Id == user.Id);

            if (dbUser is null) return new APIResponse("", false);

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

            return new APIResponse("User got updated", true);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return new APIResponse(ex.Message, false);
        }
    }
}
