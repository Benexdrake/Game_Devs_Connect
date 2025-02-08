namespace Backend.Interfaces;

public interface IProjectController
{
    Task<ActionResult> GetProject(string id);
    Task<ActionResult> AddProject(Project project);
    Task<ActionResult> UpdateProject(Project project);
    Task<ActionResult> DeleteProject(string id);
}
