namespace GameDevsConnect.Backend.API.User.Application.Repository.V1;

public interface IUserRepository
{
    Task<GetUserIdsResponse> GetIdsAsync(CancellationToken token = default);
    Task<GetUserByIdResponse> GetAsync(string id, CancellationToken token = default);
    Task<GetUserByIdResponse> GetExistAsync(string id, CancellationToken token = default);
    Task<GetCountResponse> GetFollowerCountAsync(string id, CancellationToken token = default);
    Task<GetCountResponse> GetFollowingCountAsync(string id, CancellationToken token = default);
    Task<GetUserIdsResponse> GetFollowerAsync(string id, CancellationToken token = default);
    Task<GetUserIdsResponse> GetFollowingAsync(string id, CancellationToken token = default);
    Task<GetUserIdsResponse> GetIdsByProjectIdAsync(string id, CancellationToken token = default);
    Task<ApiResponse> AddAsync(UserDTO user, CancellationToken token = default);
    Task<ApiResponse> UpdateAsync(UserDTO user, CancellationToken token = default);
    Task<ApiResponse> DeleteAsync(string id, CancellationToken token = default);
}
