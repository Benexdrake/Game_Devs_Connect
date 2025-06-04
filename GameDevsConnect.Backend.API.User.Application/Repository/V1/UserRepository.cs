namespace GameDevsConnect.Backend.API.User.Application.Repository.V1;

public class UserRepository(GDCDbContext context, IValidator<UserModel> userValidator ) : IUserRepository
{
    private readonly GDCDbContext _context = context;
    private readonly IValidator<UserModel> _userValidator = userValidator;

    public async Task<AddUpdateDeleteUserResponse> AddAsync(UserModel user, CancellationToken token = default)
    {
        try
        {
            Message.Id = user.Id;

            var valid = _userValidator.Validate(user);

            if(!valid.IsValid)
            {
                var errors = new List<string>();
                foreach (var error in valid.Errors)
                    errors.Add(error.ErrorMessage);
                var message = string.Join("\n", errors);
                Log.Error(message);
                return new AddUpdateDeleteUserResponse(message, false);
            }

            var dbUser = await _context.Users.FirstOrDefaultAsync(x => x.Id == user.Id, token);

            if (dbUser is not null)
            {
                Log.Error(Message.NOTFOUND);
                return new AddUpdateDeleteUserResponse(Message.NOTFOUND, false);
            }

            await _context.Users.AddAsync(user, token);
            await _context.SaveChangesAsync(token);

            Log.Information(Message.UPDATE);
            return new AddUpdateDeleteUserResponse(Message.ADD, true);
        }
        catch (Exception ex)
        {
            Log.Error(ex.Message);
            return new AddUpdateDeleteUserResponse(ex.Message, false);
        }
    }

    public async Task<AddUpdateDeleteUserResponse> DeleteAsync(string id, CancellationToken token = default)
    {
        try
        {
            Message.Id = id;
            var dbUser = await _context.Users.FirstOrDefaultAsync(x => x.Id == id, token);

            if (dbUser is null)
            {
                Log.Error(Message.NOTFOUND);
                return new AddUpdateDeleteUserResponse(Message.NOTFOUND, false);
            }

            _context.Users.Remove(dbUser);

            await _context.SaveChangesAsync(token);

            Log.Information(Message.DELETE);
            return new AddUpdateDeleteUserResponse(Message.DELETE, true);
        }
        catch (Exception ex)
        {
            Log.Error(ex.Message);
            return new AddUpdateDeleteUserResponse(ex.Message, false);
        }
    }

    public async Task<GetUserByIdResponse> GetAsync(string id, CancellationToken token = default)
    {
        try
        {
            Message.Id = id;
            var user = await _context.Users.FirstOrDefaultAsync(x => x.Id == id, token);

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

    public async Task<GetUserIdsResponse> GetIdsAsync(CancellationToken token = default)
    {
        try
        {
            var userIds = await _context.Users.Select(x => x.Id).ToArrayAsync(token);

            return new GetUserIdsResponse(null!, true, userIds);
        }
        catch (Exception ex)
        {
            Log.Error(ex.Message);
            return new GetUserIdsResponse(ex.Message, false, null!);
        }
    }

    public async Task<AddUpdateDeleteUserResponse> UpdateAsync(UserModel user, CancellationToken token = default)
    {
        try
        {
            Message.Id = user.Id;
            var dbUser = await _context.Users.AsNoTracking().FirstOrDefaultAsync(x => x.Id == user.Id, token);

            if (dbUser is null)
            {
                Log.Error(Message.NOTFOUND);
                return new AddUpdateDeleteUserResponse(Message.NOTFOUND, false);
            }

            _context.Users.Update(user);
            await _context.SaveChangesAsync(token);

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
