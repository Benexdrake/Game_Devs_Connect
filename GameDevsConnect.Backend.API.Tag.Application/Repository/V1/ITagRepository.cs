namespace GameDevsConnect.Backend.API.Tag.Application.Repository.V1;

public interface ITagRepository
{
    Task<GetTagsResponse> GetAsync();
    Task<ApiResponse> AddAsync(TagModel tag);
    Task<ApiResponse> UpdateAsync(TagModel tag);
    Task<ApiResponse> DeleteAsync(int id);
}
