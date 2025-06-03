namespace GameDevsConnect.Backend.API.Tag.Application.Repository;

public interface ITagRepository
{
    Task<TagModel[]> GetAsync();
    Task<bool> AddAsync(TagModel tag);
    Task<bool> UpdateAsync(TagModel tag);
    Task<bool> DeleteAsync(int id);
}
