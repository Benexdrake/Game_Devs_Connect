using GameDevsConnect.Backend.Shared.Models;

namespace GameDevsConnect.Backend.API.Gateway.Repository
{
    public interface IAuthRepository
    {
        Task<bool> AuthenticateAsync(AuthModel auth);
        Task DeleteAsync(AuthModel auth);
        Task UpsertAsync(AuthModel auth);
    }
}