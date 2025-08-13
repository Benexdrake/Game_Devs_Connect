﻿namespace GameDevsConnect.Backend.API.Project.Application.Repository.V1;

public class ProjectRepository(GDCDbContext context) : IProjectRepository
{
    private readonly GDCDbContext _context = context;
    public async Task<ApiResponse> AddAsync(UpsertProject addProject, CancellationToken token)
    {
        try
        {
            addProject.Project!.Id = Guid.NewGuid().ToString();

            var errors = await new Validation().ValidateProject(_context, ValidationMode.Add, addProject.Project, token);
            if (errors.Length > 0)
                return new ApiResponse(Message.VALIDATIONERROR(addProject.Project.OwnerId), false, errors);

            await _context.Projects.AddAsync(addProject.Project!, token);
            await _context.SaveChangesAsync();

            Log.Information(Message.ADD(addProject.Project!.Id));
            return new ApiResponse(null!, true, errors);
        }
        catch (Exception ex)
        {
            Log.Error(ex.Message);
            return new ApiResponse("", false, [ex.Message]);
        }
    }

    public async Task<ApiResponse> DeleteAsync(string id, CancellationToken token)
    {
        try
        {
            var project = await _context.Projects.FirstOrDefaultAsync(x => x.Id.Equals(id), token);

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

    public async Task<GetIdsResponse> GetIdsAsync(CancellationToken token)
    {
        try
        {
            var projectIds = await _context.Projects.Select(x => x.Id).ToArrayAsync(token);
            return new GetIdsResponse(null!, true, projectIds);
        }
        catch (Exception ex)
        {
            Log.Error(ex.Message);
            return new GetIdsResponse(ex.Message, false, null!);
        }
    }

    public async Task<GetResponse> GetByIdAsync(string id, CancellationToken token)
    {
        try
        {
            var project = await _context.Projects.SingleOrDefaultAsync(x => x.Id == id, token);

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

    public async Task<ApiResponse> UpdateAsync(UpsertProject updateProject, CancellationToken token)
    {
        try
        {
            var errors = await new Validation().ValidateProject(_context, ValidationMode.Add, updateProject.Project!, token);
            if (errors.Length > 0)
                return new ApiResponse(Message.VALIDATIONERROR(updateProject.Project!.OwnerId), false, errors);

            _context.Projects.Update(updateProject.Project!);
            await _context.SaveChangesAsync();

            Log.Information(Message.UPDATE(updateProject.Project!.Id));
            return new ApiResponse(Message.UPDATE(updateProject.Project!.Id), true);
        }
        catch (Exception ex)
        {
            Log.Error(ex.Message);
            return new ApiResponse(ex.Message, false);
        }
    }
}
