namespace Backend.Controllers;

[Route("project")]
[ApiController]
public class ProjectController(IProjectRepository projectRepository) : ControllerBase
{
    [HttpGet("{id}")]
    public async Task<ActionResult> GetProject(string id)
    {
        var result = await projectRepository.GetProjectById(id);

        return Ok(result);
    }

    [HttpPost("add")]
    public async Task<ActionResult> AddProject(Project project)
    {
        var result = await projectRepository.AddProject(project);

        return Ok(result);
    }

    [HttpPut("update")]
    public async Task<ActionResult> UpdateProject(Project project)
    {
        var result = await projectRepository.UpdateProject(project);

        return Ok(result);
    }

    [HttpDelete("delete/{id}")]
    public async Task<ActionResult> DeleteProject(string id)
    {
        var result = await projectRepository.DeleteProject(id);

        return Ok(result);
    }
}
