namespace GameDevsConnect.Backend.API.User.Repository;

public interface IUserRepository
{
    Task<APIResponse> GetIdsAsync();
    Task<APIResponse> GetAsync(string id);
    Task<APIResponse> AddAsync(UserModel user);
    Task<APIResponse> UpdateAsync(UserModel user);
    Task<APIResponse> DeleteAsync(string id);
}
