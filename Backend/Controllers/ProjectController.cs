namespace Backend.Controllers;

[Route("[controller]")]
[ApiController]
public class ProjectController(ProjectRepository projectRepository) : ControllerBase
{
    private readonly ProjectRepository _projectRepository = projectRepository;

    [HttpGet("get/{id}")]
    public async Task<ActionResult> GetProject(string id)
    {
        var project = await _projectRepository.GetProject(id);

        if (project is null) return NotFound();

        return Ok(project);
    }

    [HttpPost("add")]
    public async Task<ActionResult> AddProject(Project project)
    {
        var result = await _projectRepository.AddProject(project);

        return Ok(result);
    }

    [HttpPut("update")]
    public async Task<ActionResult> UpdateProject(Project project)
    {
        var result = await _projectRepository.UpdateProject(project);

        return Ok(result);
    }

    [HttpDelete("delete/{id}")]
    public async Task<ActionResult> DeleteProject(string id)
    {
        var result = await _projectRepository.DeleteProject(id);

        return Ok(result);
    }
}
