namespace GameDevsConnect.Backend.API.Gateway.Application.Repository.V1
{
    public interface IAuthRepository
    {
        Task<AuthenticateResponse> AuthenticateAsync(string token);
        Task DeleteAsync(AuthModel auth);
        Task UpsertAsync(AuthModel auth);
    }
}