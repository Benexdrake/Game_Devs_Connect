namespace Backend.Controllers;

[Route("[controller]")]
[ApiController]
public class ProjectController(GDCDbContext context) : ControllerBase, IProjectController
{
    private readonly GDCDbContext _context = context;

    [HttpGet]
    public async Task<ActionResult> GetProject(string id)
    {
        var project = await _context.Projects.FirstOrDefaultAsync(x => x.Equals(id));

        if (project is null) return NotFound();

        return Ok();
    }

    [HttpPost]
    public async Task<ActionResult> AddProject(Project project)
    {
        var DbProject = await _context.Projects.FirstOrDefaultAsync(x => x.Id.Equals(project.Id));

        if (DbProject is not null) return BadRequest();

        await _context.Projects.AddAsync(project);
        await _context.SaveChangesAsync();

        return Ok();
    }

    [HttpPut]
    public async Task<ActionResult> UpdateProject(Project project)
    {
        var DbProject = await _context.Projects.FirstOrDefaultAsync(x => x.Id.Equals(project.Id));

        if (DbProject is null) return BadRequest();
        
        // Update

        return Ok();
    }

    [HttpDelete]
    public async Task<ActionResult> DeleteProject(string id)
    {
        var project = await _context.Projects.FirstOrDefaultAsync(x => x.Id.Equals(id));

        if (project is null) return NotFound();

        _context.Projects.Remove(project);
        await _context.SaveChangesAsync();

        return Ok();
    }
}
