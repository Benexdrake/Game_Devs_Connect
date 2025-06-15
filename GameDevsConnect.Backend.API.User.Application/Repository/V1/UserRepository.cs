namespace GameDevsConnect.Backend.API.User.Application.Repository.V1;

public class UserRepository(GDCDbContext context) : IUserRepository
{
    private readonly GDCDbContext _context = context;


    public async Task<ApiResponse> AddAsync(UserModel user, CancellationToken token = default)
    {
        try
        {
            var userValidator = new UserValidator(_context, ValidationMode.Add);

            var valid = await userValidator.ValidateAsync(user, token);

            if (!valid.IsValid)
            {
                var errors = new List<string>();

                foreach (var error in valid.Errors)
                    errors.Add(error.ErrorMessage);

                Log.Error(Message.VALIDATIONERROR(user.Id));
                return new ApiResponse(Message.VALIDATIONERROR(user.Id), false, [.. errors]);
            }

            await _context.Users.AddAsync(user, token);
            await _context.SaveChangesAsync(token);

            Log.Information(Message.ADD(user.Id));
            return new ApiResponse(Message.ADD(user.Id), true);
        }
        catch (Exception ex)
        {
            Log.Error(ex.Message);
            return new ApiResponse(ex.Message, false);
        }
    }

    public async Task<ApiResponse> DeleteAsync(string id, CancellationToken token = default)
    {
        try
        {
            var dbUser = await _context.Users.FirstOrDefaultAsync(x => x.Id == id, token);

            if (dbUser is null)
            {
                Log.Error(Message.NOTFOUND(id));
                return new ApiResponse(Message.NOTFOUND(id), false);
            }

            _context.Users.Remove(dbUser);

            await _context.SaveChangesAsync(token);

            Log.Information(Message.DELETE(id));
            return new ApiResponse(Message.DELETE(id), true);
        }
        catch (Exception ex)
        {
            Log.Error(ex.Message);
            return new ApiResponse(ex.Message, false);
        }
    }

    public async Task<GetUserByIdResponse> GetAsync(string id, CancellationToken token = default)
    {
        try
        {
            var user = await _context.Users.FirstOrDefaultAsync(x => x.Id == id, token);

            if (user is null)
            {
                Log.Error(Message.NOTFOUND(id));
                return new GetUserByIdResponse(Message.NOTFOUND(id), false, null!);
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

    public async Task<ApiResponse> UpdateAsync(UserModel user, CancellationToken token = default)
    {
        try
        {
            var userValidator = new UserValidator(_context, ValidationMode.Update);

            var valid = await userValidator.ValidateAsync(user, token);

            if (!valid.IsValid)
            {
                var errors = new List<string>();

                foreach (var error in valid.Errors)
                    errors.Add(error.ErrorMessage);

                Log.Error(Message.VALIDATIONERROR(user.Id));
                return new ApiResponse(Message.VALIDATIONERROR(user.Id), false, [.. errors]);
            }

            _context.Users.Update(user);
            await _context.SaveChangesAsync(token);

            Log.Information(Message.UPDATE(user.Id));
            return new ApiResponse(Message.UPDATE(user.Id), true);
        }
        catch (Exception ex)
        {
            Log.Error(ex.Message);
            return new ApiResponse(ex.Message, false);
        }
    }
}
