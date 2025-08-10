namespace GameDevsConnect.Backend.API.Tag.Application.Repository.V1;

public interface ITagRepository
{
    Task<TagDTO[]> GetAsync(CancellationToken token);
    Task<bool> AddAsync(TagDTO tag, CancellationToken token);
    Task<bool> UpdateAsync(TagDTO tag, CancellationToken token);
    Task<bool> DeleteAsync(string tag, CancellationToken token);
}
