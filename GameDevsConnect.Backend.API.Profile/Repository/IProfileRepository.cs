namespace GameDevsConnect.Backend.API.Profile.Repository;

public interface IProfileRepository
{
    Task<APIResponse> GetAsync(string id);
    Task<APIResponse> AddAsync(ProfileModel profile);
    Task<APIResponse> UpdateAsync(ProfileModel profile);
    Task<APIResponse> DeleteAsync(string id);
}
