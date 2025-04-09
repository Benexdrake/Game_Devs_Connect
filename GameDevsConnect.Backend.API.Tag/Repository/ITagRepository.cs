namespace GameDevsConnect.Backend.API.Tag.Repository;

public interface ITagRepository
{
    Task<APIResponse> GetAsync();
    Task<APIResponse> GetByRequestIdAsync(string id);
    Task<APIResponse> AddAsync(TagModel tag);
    Task<APIResponse> UpdateAsync(TagModel tag);
    Task<APIResponse> DeleteAsync(int id);
}
