
namespace GameDevsConnect.Backend.API.Tag.Application.Services;

public interface ITagService
{
    Task<GetTagsResponse> GetAsync(CancellationToken token);
    Task<ApiResponse> AddAsync(TagDTO tag, CancellationToken token);
    Task<ApiResponse> UpdateAsync(TagDTO tag, CancellationToken token);
    Task<ApiResponse> DeleteAsync(string tag, CancellationToken token);
}
