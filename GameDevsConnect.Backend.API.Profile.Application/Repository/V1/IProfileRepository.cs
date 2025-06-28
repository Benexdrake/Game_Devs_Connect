namespace GameDevsConnect.Backend.API.Profile.Application.Repository.V1;

public interface IProfileRepository
{
    Task<GetResponse> GetAsync(string id, CancellationToken token);
    Task<GetFullResponse> GetFullAsync(string id, CancellationToken token);
    Task<ApiResponse> AddAsync(ProfileDTO profile, CancellationToken token);
    Task<ApiResponse> UpdateAsync(ProfileDTO profile, CancellationToken token);
    Task<ApiResponse> DeleteAsync(string id, CancellationToken token);
}
