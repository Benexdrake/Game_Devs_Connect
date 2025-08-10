namespace GameDevsConnect.Backend.API.User.Application.Services;

public class UserService(GDCDbContext context, IUserRepository repo) : IUserService
{
    private readonly GDCDbContext _context = context;
    private readonly IUserRepository _repo = repo;

    public async Task<GetUserIdResponse> AddAsync(UserDTO user, CancellationToken token = default)
    {
        try
        {
            string id = await _repo.AddAsync(user, token);
            return new GetUserIdResponse("", !id.Equals(string.Empty), id);
        }
        catch (Exception ex)
        {
            Log.Error(ex.Message);
            return new GetUserIdResponse(ex.Message, false, null!);
        }
    }

    public async Task<ApiResponse> DeleteAsync(string id, CancellationToken token = default)
    {
        try
        {
            var status = await _repo.DeleteAsync(id, token);
            return new ApiResponse("", status);
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
            var user = await _repo.GetAsync(id, token);
            return new GetUserByIdResponse("", user is not null, user!);
        }
        catch (Exception ex)
        {
            Log.Error(ex.Message);
            return new GetUserByIdResponse(ex.Message, false, null!);
        }
    }

    public async Task<ApiResponse> GetExistAsync(string id, CancellationToken token = default)
    {
        try
        {
            var exist = await _repo.GetExistAsync(id, token);
            return new ApiResponse("", exist);
        }
        catch (Exception ex)
        {
            Log.Error(ex.Message);
            return new ApiResponse(ex.Message, false);
        }
    }

    public async Task<GetUserIdsResponse> GetFollowerAsync(string id, CancellationToken token = default)
    {
        try
        {
            var ids = await _repo.GetFollowerAsync(id, token);
            return new GetUserIdsResponse("", true, ids);
        }
        catch (Exception ex)
        {
            Log.Error(ex.Message);
            return new GetUserIdsResponse(ex.Message, false, null!);
        }
    }

    public async Task<GetCountResponse> GetFollowerCountAsync(string id, CancellationToken token = default)
    {
        try
        {
            var count = await _repo.GetFollowerCountAsync(id, token);
            return new GetCountResponse("", true, count);
        }
        catch (Exception ex)
        {
            Log.Error(ex.Message);
            return new GetCountResponse(ex.Message, false, 0);
        }
    }

    public async Task<GetUserIdsResponse> GetFollowingAsync(string id, CancellationToken token = default)
    {
        try
        {
            var ids = await _repo.GetFollowingAsync(id, token);
            return new GetUserIdsResponse("", true, ids);
        }
        catch (Exception ex)
        {
            Log.Error(ex.Message);
            return new GetUserIdsResponse(ex.Message, false, []);
        }
    }

    public async Task<GetCountResponse> GetFollowingCountAsync(string id, CancellationToken token = default)
    {
        try
        {
            var count = await _repo.GetFollowingCountAsync(id, token);
            return new GetCountResponse("", true, count);
        }
        catch (Exception ex)
        {
            Log.Error(ex.Message);
            return new GetCountResponse(ex.Message, false, 0);
        }
    }

    public async Task<GetUserIdsResponse> GetIdsAsync(CancellationToken token = default)
    {
        try
        {
            var ids = await _repo.GetIdsAsync(token);
            return new GetUserIdsResponse("", true, ids);
        }
        catch (Exception ex)
        {
            Log.Error(ex.Message);
            return new GetUserIdsResponse(ex.Message, false, []);
        }
    }

    public async Task<GetUserIdsResponse> GetIdsByProjectIdAsync(string id, CancellationToken token = default)
    {
        try
        {
            var ids = await _repo.GetIdsByProjectIdAsync(id, token);
            return new GetUserIdsResponse("", true, ids);
        }
        catch (Exception ex)
        {
            Log.Error(ex.Message);
            return new GetUserIdsResponse(ex.Message, false, []);
        }
    }

    public async Task<ApiResponse> UpdateAsync(UserDTO user, CancellationToken token = default)
    {
        try
        {
            
            var status = await _repo.UpdateAsync(user, token);
            return new ApiResponse("", status);
        }
        catch (Exception ex)
        {
            Log.Error(ex.Message);
            return new ApiResponse(ex.Message, false);
        }
    }
}