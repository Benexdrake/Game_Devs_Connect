namespace Backend.Interfaces;
public interface IAuthRepository
{
    Task<APIResponse> Get(string userId);
    Task<APIResponse> Add(Auth auth);
    Task<APIResponse> Update(Auth auth);
    Task<APIResponse> Delete(string userId);
}