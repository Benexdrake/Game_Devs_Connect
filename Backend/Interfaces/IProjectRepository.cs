namespace Backend.Interfaces;

public interface IProjectRepository
{
    Task<IEnumerable<Project>> GetProjectsByUserID(string userId);
    Task<Project> GetProject(string id);
    Task<bool> AddProject(Project project);
    Task<bool> UpdateProject(Project project);
    Task<bool> DeleteProject(string id);
}
