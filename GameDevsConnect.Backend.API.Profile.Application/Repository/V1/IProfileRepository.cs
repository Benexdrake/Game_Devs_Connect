namespace GameDevsConnect.Backend.API.Profile.Application.Repository.V1;

public interface IProfileRepository
{
    Task<GetResponse> GetAsync(string id);
    Task<GetFullResponse> GetFullAsync(string id);
    Task<ApiResponse> AddAsync(ProfileDTO profile);
    Task<ApiResponse> UpdateAsync(ProfileDTO profile);
    Task<ApiResponse> DeleteAsync(string id);
}
