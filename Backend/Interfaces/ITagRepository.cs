namespace Backend.Interfaces;

public interface ITagRepository
{
    Task<APIResponse> GetTags();
    Task<APIResponse> AddTag(Tag tag);
    Task<APIResponse> UpdateTag(Tag tag);
    Task<APIResponse> DeleteTag(int id);
}
