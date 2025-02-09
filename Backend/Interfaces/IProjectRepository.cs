namespace Backend.Interfaces;

public interface IProjectRepository
{
    Task<APIResponse> GetProjectById(string id);
    Task<APIResponse> AddProject(Project project);
    Task<APIResponse> UpdateProject(Project project);
    Task<APIResponse> DeleteProject(string id);
}
