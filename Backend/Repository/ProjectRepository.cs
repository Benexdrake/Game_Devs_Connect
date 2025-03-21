namespace Backend.Repository;

public class ProjectRepository(GdcContext context) : IProjectRepository
{
    private readonly GdcContext _context = context;
    public async Task<APIResponse> AddProject(Project project)
    {
        try
        {
            var dbProject = await _context.Projects.FirstOrDefaultAsync(x => x.Id.Equals(project.Id));
            if(dbProject is not null) return new APIResponse("Project exists in DB",false, new { });

            await _context.Projects.AddAsync(project);
            await _context.SaveChangesAsync();
            return new APIResponse("Project saved", true, new { });
        }
        catch(Exception ex) 
        {
            Log.Error(ex.Message);
            return new APIResponse(ex.Message, false, new { });
        }
    }

    public async Task<APIResponse> DeleteProject(string id)
    {
        try
        {
            var project = await _context.Projects.FirstOrDefaultAsync(x => x.Id.Equals(id));

            if (project is null) return new APIResponse("Project didnt exist", false, new { });

            _context.Projects.Remove(project);
            await _context.SaveChangesAsync();

            return new APIResponse("Project got deleted", true, new { });
        }
        catch (Exception ex)
        {
            Log.Error(ex.Message);
            return new APIResponse(ex.Message, false, new { });
        }
    }

    public async Task<APIResponse> GetProjectById(string id)
    {
        var project = await _context.Projects.SingleOrDefaultAsync(x => x.Id == id);

        if (project is null) return new APIResponse("Project didnt exist", false, new { });

        return new APIResponse("", true, project);
    }

    public async Task<APIResponse> UpdateProject(Project project)
    {
        try
        {
            var DbProject = await _context.Projects.AsNoTracking().FirstOrDefaultAsync(x => x.Id.Equals(project.Id));
            if (DbProject is null) return new APIResponse("Project dont exist", false, new { });

            _context.Projects.Update(project);
            await _context.SaveChangesAsync();

            return new APIResponse("Project updated", true, new { });
        }
        catch(Exception ex)
        {
            Log.Error(ex.Message);
            return new APIResponse(ex.Message, false, new { });
        }
    }
}
