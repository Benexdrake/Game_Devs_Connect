namespace GameDevsConnect.Backend.API.User.Application.Repository.V1;

public class UserRepository(GDCDbContext context) : IUserRepository
{
    private readonly GDCDbContext _context = context;
    public async Task<AddUpdateDeleteUserResponse> AddAsync(UserModel user)
    {
        try
        {
            Message.Id = user.Id;
            var dbUser = await _context.Users.FirstOrDefaultAsync(x => x.Id == user.Id);

            if (dbUser is not null)
            {
                Log.Error(Message.NOTFOUND);
                return new AddUpdateDeleteUserResponse(Message.NOTFOUND, false);
            }

            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();

            Log.Information(Message.UPDATE);
            return new AddUpdateDeleteUserResponse(Message.ADD, true);
        }
        catch (Exception ex)
        {
            Log.Error(ex.Message);
            return new AddUpdateDeleteUserResponse(ex.Message, false);
        }
    }

    public async Task<AddUpdateDeleteUserResponse> DeleteAsync(string id)
    {
        try
        {
            Message.Id = id;
            var dbUser = await _context.Users.FirstOrDefaultAsync(x => x.Id == id);

            if (dbUser is null)
            {
                Log.Error(Message.NOTFOUND);
                return new AddUpdateDeleteUserResponse(Message.NOTFOUND, false);
            }

            _context.Users.Remove(dbUser);

            await _context.SaveChangesAsync();

            Log.Information(Message.DELETE);
            return new AddUpdateDeleteUserResponse(Message.DELETE, true);
        }
        catch (Exception ex)
        {
            Log.Error(ex.Message);
            return new AddUpdateDeleteUserResponse(ex.Message, false);
        }
    }

    public async Task<GetUserByIdResponse> GetAsync(string id)
    {
        try
        {
            Message.Id = id;
            var user = await _context.Users.FirstOrDefaultAsync(x => x.Id == id);

            if (user is null)
            {
                Log.Error(Message.NOTFOUND);
                return new GetUserByIdResponse(Message.NOTFOUND, false, null!);
            }

            return new GetUserByIdResponse(null!, true, user!);
        }
        catch (Exception ex)
        {
            Log.Error(ex.Message);
            return new GetUserByIdResponse(ex.Message, false, null!);
        }
    }

    public async Task<GetUserIdsResponse> GetIdsAsync()
    {
        try
        {
            var userIds = await _context.Users.Select(x => x.Id).ToArrayAsync();

            return new GetUserIdsResponse(null!, true, userIds);
        }
        catch (Exception ex)
        {
            Log.Error(ex.Message);
            return new GetUserIdsResponse(ex.Message, false, null!);
        }
    }

    public async Task<AddUpdateDeleteUserResponse> UpdateAsync(UserModel user)
    {
        try
        {
            Message.Id = user.Id;
            var dbUser = await _context.Users.AsNoTracking().FirstOrDefaultAsync(x => x.Id == user.Id);

            if (dbUser is null)
            {
                Log.Error(Message.NOTFOUND);
                return new AddUpdateDeleteUserResponse(Message.NOTFOUND, false);
            }

            _context.Users.Update(user);
            await _context.SaveChangesAsync();

            Log.Information(Message.UPDATE);
            return new AddUpdateDeleteUserResponse(Message.UPDATE, true);
        }
        catch (Exception ex)
        {
            Log.Error(ex.Message);
            return new AddUpdateDeleteUserResponse(ex.Message, false);
        }
    }
}
