namespace GameDevsConnect.Backend.API.Tag.Application.Services.V1;

public interface ITagService
{
    Task<APIResponse> GetAsync();
    Task<APIResponse> AddAsync(TagModel tag);
    Task<APIResponse> UpdateAsync(TagModel tag);
    Task<APIResponse> DeleteAsync(int id);
}
