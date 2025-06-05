namespace GameDevsConnect.Backend.API.Project.Application.Repository.V1;

public class ProjectRepository(GDCDbContext context) : IProjectRepository
{
    private readonly GDCDbContext _context = context;
    public async Task<ApiResponse> AddAsync(UpsertRequest addRequest)
    {
        try
        {
            Message.Id = addRequest.Project!.Id;
            var dbProject = await _context.Projects.FirstOrDefaultAsync(x => x.Id.Equals(addRequest.Project!.Id));
            if(dbProject is not null)
            {
                Log.Error(Message.EXIST);
                return new ApiResponse(Message.EXIST, false);
            }

            await _context.Projects.AddAsync(addRequest.Project);
            await _context.SaveChangesAsync();

            Log.Information(Message.ADD);
            return new ApiResponse(null!, true);
        }
        catch(Exception ex) 
        {
            Log.Error(ex.Message);
            return new ApiResponse(ex.Message, false);
        }
    }

    public async Task<ApiResponse> DeleteAsync(string id)
    {
        try
        {
            Message.Id = id;
            var project = await _context.Projects.FirstOrDefaultAsync(x => x.Id.Equals(id));

            if (project is null)
            {
                Log.Error(Message.NOTFOUND);
                return new ApiResponse(Message.NOTFOUND, false);
            }

            _context.Projects.Remove(project!);
            await _context.SaveChangesAsync();

            Log.Information(Message.DELETE);
            return new ApiResponse(Message.DELETE, true);
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
        catch(Exception ex)
        {
            Log.Error(ex.Message);
            return new GetIdsResponse(ex.Message, false, null!);
        }
    }

    public async Task<GetResponse> GetByIdAsync(string id)
    {
        try
        {
            Message.Id = id;
            var project = await _context.Projects.SingleOrDefaultAsync(x => x.Id == id);

            if (project is null)
            {
                Log.Error(Message.NOTFOUND);
                return new GetResponse(Message.NOTFOUND, false, null!);
            }

            return new GetResponse(null!, true, project);   
        }
        catch(Exception ex)
        {
            Log.Error(ex.Message);
            return new GetResponse(ex.Message, false, null!);
        }
    }

    public async Task<ApiResponse> UpdateAsync(UpsertRequest updateRequest)
    {
        try
        {
            Message.Id = updateRequest.Project!.Id;
            var DbProject = await _context.Projects.AsNoTracking().FirstOrDefaultAsync(x => x.Id.Equals(updateRequest.Project.Id));
            if (DbProject is null)
            {
                Log.Error(Message.NOTFOUND);
                return new ApiResponse(Message.NOTFOUND, false);
            }

            _context.Projects.Update(updateRequest.Project);
            await _context.SaveChangesAsync();

            Log.Information(Message.UPDATE);
            return new ApiResponse(Message.UPDATE, true);
        }
        catch(Exception ex)
        {
            Log.Error(ex.Message);
            return new ApiResponse(ex.Message, false);
        }
    }
}
