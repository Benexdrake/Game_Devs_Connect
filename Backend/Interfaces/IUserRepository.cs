namespace Backend.Interfaces;

public interface IUserRepository
{
    Task<APIResponse> GetUsersAsync();
    Task<APIResponse> GetUserAsync(string id);
    Task<APIResponse> AddUserAsync(User user);
    Task<APIResponse> UpdateUserAsync(User user);
    Task<APIResponse> DeleteUserAsync(string id);
}
