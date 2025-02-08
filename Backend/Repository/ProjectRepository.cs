namespace Backend.Repository;

public class ProjectRepository(GDCDbContext context) : IProjectRepository
{
    private readonly GDCDbContext _context = context;
    public async Task<bool> AddProject(Project project)
    {
        try
        {
            var dbProject = await _context.Projects.FirstOrDefaultAsync(x => x.Id.Equals(project.Id));
            if(dbProject is not null) return false;

            await _context.Projects.AddAsync(project);
            await _context.SaveChangesAsync();
            return true;
        }
        catch(Exception ex) 
        {
            Console.WriteLine(ex.Message);
            return false;
        }
    }

    public async Task<bool> DeleteProject(string id)
    {
        try
        {
            var project = await _context.Projects.FirstOrDefaultAsync(x => x.Id.Equals(id));

            if (project is null) return false ;

            _context.Projects.Remove(project);
            await _context.SaveChangesAsync();

            return true;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return false;
        }
    }

    public async Task<Project> GetProject(string id)
    {
        var projects = await _context.Projects.SingleOrDefaultAsync(x => x.Id == id);
        return projects;
    }

    public Task<IEnumerable<Project>> GetProjectsByUserID(string userId)
    {
        throw new NotImplementedException();
    }

    public async Task<bool> UpdateProject(Project project)
    {
        try
        {
            var DbProject = await _context.Projects.FirstOrDefaultAsync(x => x.Id.Equals(project.Id));
            if (DbProject is null) return false;

            DbProject.Title = project.Title;
            DbProject.Description = project.Description;
            DbProject.Header = project.Header;
            DbProject.UserIds = project.UserIds;
            DbProject.Elements = project.Elements;

            await _context.SaveChangesAsync();

            return true;
        }
        catch(Exception ex)
        {
            Console.WriteLine(ex.Message);
            return false;
        }
    }
}
