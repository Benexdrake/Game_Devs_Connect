namespace GameDevsConnect.Backend.API.User.Application.Repository.V1;

public interface IUserRepository
{
    Task<GetUserIdsResponse> GetIdsAsync(CancellationToken token = default);
    Task<GetUserByIdResponse> GetAsync(string id, CancellationToken token = default);
    Task<AddUpdateDeleteUserResponse> AddAsync(UserModel user, CancellationToken token = default);
    Task<AddUpdateDeleteUserResponse> UpdateAsync(UserModel user, CancellationToken token = default);
    Task<AddUpdateDeleteUserResponse> DeleteAsync(string id, CancellationToken token = default);
}
