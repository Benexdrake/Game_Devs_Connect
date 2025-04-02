namespace GameDevsConnect.Backend.API.Auth.Repository;
public interface IAuthRepository
{
    Task<APIResponse> Get(string userId);
    Task<APIResponse> Add(AuthModel auth);
    Task<APIResponse> Update(AuthModel auth);
    Task<APIResponse> Delete(string userId);
}