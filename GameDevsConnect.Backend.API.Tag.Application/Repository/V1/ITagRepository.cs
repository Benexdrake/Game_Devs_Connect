namespace GameDevsConnect.Backend.API.Tag.Application.Repository.V1;

public interface ITagRepository
{
    Task<GetTagsResponse> GetAsync();
    Task<AddUpdateDeleteTagResponse> AddAsync(TagModel tag);
    Task<AddUpdateDeleteTagResponse> UpdateAsync(TagModel tag);
    Task<AddUpdateDeleteTagResponse> DeleteAsync(int id);
}
