namespace Backend.Interfaces;

public interface IUserRepository
{
    Task<IEnumerable<User>> GetUsersAsync();
    Task<User> GetUserAsync(string id);
    Task<bool> AddUserAsync(User user);
    Task<bool> UpdateUserAsync(User user);
    Task<bool> DeleteUserAsync(string id);
}
