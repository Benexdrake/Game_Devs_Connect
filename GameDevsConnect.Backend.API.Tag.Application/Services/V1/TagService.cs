
using Azure;
using GameDevsConnect.Backend.API.Tag.Application.Repository;

namespace GameDevsConnect.Backend.API.Tag.Application.Services.V1;

public class TagService(ITagRepository repo) : ITagService
{
    private readonly ITagRepository repo = repo;

    public async Task<APIResponse> AddAsync(TagModel tag)
    {
        var response = await repo.AddAsync(tag);
        return new APIResponse(response, new { });
    }

    public async Task<APIResponse> DeleteAsync(int id)
    {
        var response = await repo.DeleteAsync(id);
        return new APIResponse(response, new { });
    }

    public async Task<APIResponse> GetAsync()
    {
        var response = await repo.GetAsync();
        return new APIResponse(response is not null, new { });
    }

    public async Task<APIResponse> UpdateAsync(TagModel tag)
    {
        var response = await repo.UpdateAsync(tag);
        return new APIResponse(response, new { });
    }
}
