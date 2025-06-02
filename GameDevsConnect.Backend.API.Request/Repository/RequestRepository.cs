using GameDevsConnect.Backend.Shared.Data;

namespace GameDevsConnect.Backend.API.Request.Repository;

public class RequestRepository(GDCDbContext context) : IRequestRepository
{
    private readonly GDCDbContext _context = context;

    public async Task<APIResponse> AddAsync(RequestModel request, TagModel[] tags)
    {
        try
        {
            var requestDb = await _context.Requests.FirstOrDefaultAsync(x => x.Id.Equals(request.Id));

            if (requestDb is not null) return new APIResponse("Request Exists in DB",false, new { });

            await _context.Requests.AddAsync(request);
            _context.SaveChanges();

            await _context.SaveChangesAsync();
        
            return new APIResponse("Request saved in DB", true, new {});
        }
        catch (Exception ex)
        {
            Log.Error(ex.Message);
            return new APIResponse(ex.Message, false, new { });
        }
    }

    public async Task<APIResponse> DeleteAsync(string id)
    {
        try
        {
            var request = await _context.Requests.FirstOrDefaultAsync(x => x.Id.Equals(id));

            if (request is null) return new APIResponse("Request dont exist", false, new { });

            _context.Requests.Remove(request);
            await _context.SaveChangesAsync();

            return new APIResponse("Request got deleted", true, new { });
        }
        catch (Exception ex)
        {
            Log.Error(ex.Message);
            return new APIResponse(ex.Message, false, new { });
        }
    }

    public async Task<APIResponse> GetByIdAsync(string id)
    {
        try
        {
            var request = await _context.Requests.FirstOrDefaultAsync(x => x.Id.Equals(id));

            if (request is null) return new APIResponse("Request dont exist", false, new { });

            return new APIResponse("", true, request);
        }
        catch (Exception ex)
        {
            Log.Error(ex.Message);
            return new APIResponse(ex.Message, false, new { });
        }
    }

    public async Task<APIResponse> GetIdsAsync()
    {
        var requests = await _context.Requests.OrderByDescending(x => x.Created).Select(x => x.Id).ToListAsync();
        return new APIResponse("", true, requests);
    }

    public async Task<APIResponse> GetByUserIdAsync(string userId)
    {
        var requests = await _context.Requests.Where(x => x.OwnerId.Equals(userId)).OrderByDescending(x => x.Created).Select(x => x.Id).ToListAsync();
        return new APIResponse("", true, requests);
    }

    public async Task<APIResponse> UpdateAsync(RequestModel request)
    {
        try
        {
            var Dbrequest = await _context.Requests.AsNoTracking().FirstOrDefaultAsync(x => x.Id.Equals(request.Id));

            if (Dbrequest is null) return new APIResponse("Request dont exist", false, new { });

            _context.Requests.Update(request);
            await _context.SaveChangesAsync();

            return new APIResponse("Request got updated", true, new { });
        }
        catch (Exception ex)
        {
            Log.Error(ex.Message);
            return new APIResponse(ex.Message, false, new { });
        }
    }

    public async Task<APIResponse> GetFullByIdAsync(string id)
    {
        try
        {
            var request = await _context.Requests.FirstOrDefaultAsync(x => x.Id.Equals(id));
            if (request is null) return new APIResponse("Request dont exist", false, new { });
            
            // get Tag IDs from RequestTags
            var requestTags = await _context.RequestTags.Where(rt => rt.RequestId!.Equals(id)).ToListAsync();

            // get Tags from TagIDS Array
            var tags = new List<TagModel>();

            foreach (var rt in requestTags)
            {
                var tag = await _context.Tags.FirstOrDefaultAsync(x => x.Id == rt.TagId);
                if(tag is null) continue;
                    tags.Add(tag);
            }

            // Project
            var projectTitle = await _context.Projects.Where(x => x.Id.Equals(request.ProjectId)).Select(x => x.Title).FirstAsync();

            // Owner
            var owner = await _context.Users.FirstOrDefaultAsync(x => x.Id.Equals(request.OwnerId));

            // File
            var file = await _context.Files.FirstOrDefaultAsync(x => x.Id.Equals(request.FileId));

            // Send an Object with Request, Tags, User
            var response = new {request, tags, projectTitle, owner, file };

            return new APIResponse("", true, response);
        }
        catch (Exception ex)
        {
            Log.Error(ex.Message);
            return new APIResponse(ex.Message, false, new { });
        }
    }
}
