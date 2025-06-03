namespace GameDevsConnect.Backend.API.User.Application.Repository;

public interface IUserRepository
{
    Task<string[]> GetIdsAsync();
    Task<UserModel> GetAsync(string id);
    Task<bool> AddAsync(UserModel user);
    Task<bool> UpdateAsync(UserModel user);
    Task<bool> DeleteAsync(string id);
}
