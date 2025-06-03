namespace GameDevsConnect.Backend.API.User.Application.Services.V1;
public class UserService(IUserRepository repo) : IUserService
{
    private readonly IUserRepository repo = repo;

    public async Task<APIResponse> AddAsync(UserModel user)
    {
        var response = await repo.AddAsync(user);
        return new APIResponse(response, new {});
    }

    public async Task<APIResponse> DeleteAsync(string id)
    {
        var response = await repo.DeleteAsync(id);
        return new APIResponse(response, new {});
    }

    public async Task<APIResponse> GetAsync(string id)
    {
        var response = await repo.GetAsync(id);
        return new APIResponse(response is not null, response!);
    }

    public async Task<APIResponse> GetIdsAsync()
    {
        var response = await repo.GetIdsAsync();
        return new APIResponse(response is not null, response!);
    }

    public async Task<APIResponse> UpdateAsync(UserModel user)
    {
        var response = await repo.UpdateAsync(user);
        return new APIResponse(response, new {});
    }
}
