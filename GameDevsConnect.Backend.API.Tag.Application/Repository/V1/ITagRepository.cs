namespace GameDevsConnect.Backend.API.Tag.Application.Repository.V1;

public interface ITagRepository
{
    Task<GetTagsResponse> GetAsync();
    Task<ApiResponse> AddAsync(TagDTO tag);
    Task<ApiResponse> UpdateAsync(TagDTO tag);
    Task<ApiResponse> DeleteAsync(int id);
}
