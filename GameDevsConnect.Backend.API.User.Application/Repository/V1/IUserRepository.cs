namespace GameDevsConnect.Backend.API.User.Application.Repository.V1;

public interface IUserRepository
{
    Task<GetUserIdsResponse> GetIdsAsync();
    Task<GetUserByIdResponse> GetAsync(string id);
    Task<AddUpdateDeleteUserResponse> AddAsync(UserModel user);
    Task<AddUpdateDeleteUserResponse> UpdateAsync(UserModel user);
    Task<AddUpdateDeleteUserResponse> DeleteAsync(string id);
}
