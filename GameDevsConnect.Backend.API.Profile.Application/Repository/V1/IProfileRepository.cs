namespace GameDevsConnect.Backend.API.Profile.Application.Repository.V1;

public interface IProfileRepository
{
    Task<GetResponse> GetAsync(string id);
    Task<GetFullResponse> GetFullAsync(string id);
    Task<AddUpdateDeleteResponse> AddAsync(ProfileModel profile);
    Task<AddUpdateDeleteResponse> UpdateAsync(ProfileModel profile);
    Task<AddUpdateDeleteResponse> DeleteAsync(string id);
}
