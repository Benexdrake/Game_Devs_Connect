namespace GameDevsConnect.Backend.API.User.Application.Repository.V1;

public interface IUserRepository
{
    Task<GetUserIdsResponse> GetIdsAsync(CancellationToken token = default);
    Task<GetUserByIdResponse> GetAsync(string id, CancellationToken token = default);
    Task<ApiResponse> AddAsync(UserModel user, CancellationToken token = default);
    Task<ApiResponse> UpdateAsync(UserModel user, CancellationToken token = default);
    Task<ApiResponse> DeleteAsync(string id, CancellationToken token = default);
}
