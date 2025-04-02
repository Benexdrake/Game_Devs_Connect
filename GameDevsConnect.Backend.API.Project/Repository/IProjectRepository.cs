namespace GameDevsConnect.Backend.API.Project.Repository;

public interface IProjectRepository
{
    Task<APIResponse> GetIdsAsync();
    Task<APIResponse> GetByIdAsync(string id);
    Task<APIResponse> AddAsync(ProjectModel project);
    Task<APIResponse> UpdateAsync(ProjectModel project);
    Task<APIResponse> DeleteAsync(string id);
}
