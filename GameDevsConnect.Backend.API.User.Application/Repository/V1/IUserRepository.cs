namespace GameDevsConnect.Backend.API.User.Application.Repository.V1;

public interface IUserRepository
{
    Task<string[]> GetIdsAsync(CancellationToken token = default);
    Task<UserDTO?> GetAsync(string id, CancellationToken token = default);
    Task<bool> GetExistAsync(string id, CancellationToken token = default);
    Task<int> GetFollowerCountAsync(string id, CancellationToken token = default);
    Task<int> GetFollowingCountAsync(string id, CancellationToken token = default);
    Task<string[]> GetFollowerAsync(string id, CancellationToken token = default);
    Task<string[]> GetFollowingAsync(string id, CancellationToken token = default);
    Task<string[]> GetIdsByProjectIdAsync(string id, CancellationToken token = default);
    Task<string> AddAsync(UserDTO user, CancellationToken token = default);
    Task<bool> UpdateAsync(UserDTO user, CancellationToken token = default);
    Task<bool> DeleteAsync(string id, CancellationToken token = default);
}
