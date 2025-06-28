namespace GameDevsConnect.Backend.API.Project.Application.Repository.V1;

public class ProjectRepository(GDCDbContext context) : IProjectRepository
{
    private readonly GDCDbContext _context = context;
    public async Task<ApiResponse> AddAsync(UpsertProject addProject)
    {
        try
        {
            var dbProject = await _context.Projects.FirstOrDefaultAsync(x => x.Id.Equals(addProject.Project!.Id));
            if (dbProject is not null)
            {
                Log.Error(Message.EXIST(addProject.Project!.Id));
                return new ApiResponse(Message.EXIST(addProject.Project!.Id), false);
            }

            await _context.Projects.AddAsync(addProject.Project);
            await _context.SaveChangesAsync();

            Log.Information(Message.ADD(addProject.Project!.Id));
            return new ApiResponse(null!, true);
        }
        catch (Exception ex)
        {
            Log.Error(ex.Message);
            return new ApiResponse(ex.Message, false);
        }
    }

    public async Task<ApiResponse> DeleteAsync(string id)
    {
        try
        {
            var project = await _context.Projects.FirstOrDefaultAsync(x => x.Id.Equals(id));

            if (project is null)
            {
                Log.Error(Message.NOTFOUND(id));
                return new ApiResponse(Message.NOTFOUND(id), false);
            }

            _context.Projects.Remove(project!);
            await _context.SaveChangesAsync();

            Log.Information(Message.DELETE(id));
            return new ApiResponse(Message.DELETE(id), true);
        }
        catch (Exception ex)
        {
            Log.Error(ex.Message);
            return new ApiResponse(ex.Message, false);
        }
    }

    public async Task<GetIdsResponse> GetIdsAsync()
    {
        try
        {
            var projectIds = await _context.Projects.Select(x => x.Id).ToArrayAsync();
            return new GetIdsResponse(null!, true, projectIds);
        }
        catch (Exception ex)
        {
            Log.Error(ex.Message);
            return new GetIdsResponse(ex.Message, false, null!);
        }
    }

    public async Task<GetResponse> GetByIdAsync(string id)
    {
        try
        {
            var project = await _context.Projects.SingleOrDefaultAsync(x => x.Id == id);

            if (project is null)
            {
                Log.Error(Message.NOTFOUND(id));
                return new GetResponse(Message.NOTFOUND(id), false, null!);
            }

            return new GetResponse(null!, true, project);
        }
        catch (Exception ex)
        {
            Log.Error(ex.Message);
            return new GetResponse(ex.Message, false, null!);
        }
    }

    public async Task<ApiResponse> UpdateAsync(UpsertProject updateRequest)
    {
        try
        {
            var DbProject = await _context.Projects.AsNoTracking().FirstOrDefaultAsync(x => x.Id.Equals(updateRequest.Project.Id));
            if (DbProject is null)
            {
                Log.Error(Message.NOTFOUND(updateRequest.Project!.Id));
                return new ApiResponse(Message.NOTFOUND(updateRequest.Project!.Id), false);
            }

            _context.Projects.Update(updateRequest.Project);
            await _context.SaveChangesAsync();

            Log.Information(Message.UPDATE(updateRequest.Project!.Id));
            return new ApiResponse(Message.UPDATE(updateRequest.Project!.Id), true);
        }
        catch (Exception ex)
        {
            Log.Error(ex.Message);
            return new ApiResponse(ex.Message, false);
        }
    }
}
