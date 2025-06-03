namespace GameDevsConnect.Backend.API.User.Application.Services.V1;

public interface IUserService
{
    Task<APIResponse> GetIdsAsync();
    Task<APIResponse> GetAsync(string id);
    Task<APIResponse> AddAsync(UserModel user);
    Task<APIResponse> UpdateAsync(UserModel user);
    Task<APIResponse> DeleteAsync(string id);
}
