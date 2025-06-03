namespace GameDevsConnect.Backend.API.Request.Application.Repository;

public class RequestRepository(GDCDbContext context) : IRequestRepository
{
    private readonly GDCDbContext _context = context;

    public async Task<bool> AddAsync(AddRequest addRequest)
    {
        try
        {
            var requestDb = await _context.Requests.FirstOrDefaultAsync(x => x.Id.Equals(addRequest.Request!.Id));

            if (requestDb is not null)
            {
                Log.Error($"Request: {requestDb.Id} exists already");
                return false;
            }

            await _context.Requests.AddAsync(addRequest.Request!);

            foreach(var tag in addRequest.Tags!)
            {
                _context.RequestTags.Add(new RequestTag(addRequest.Request.Id, tag.Id));
            }

            await _context.SaveChangesAsync();

            return true;
        }
        catch (Exception ex)
        {
            Log.Error(ex.Message);
            return false;
        }
    }

    public async Task<bool> DeleteAsync(string id)
    {
        try
        {
            var request = await _context.Requests.FirstOrDefaultAsync(x => x.Id.Equals(id));

            if (request is null)
            {
                Log.Error($"Unable to delete {id}");
                return false;
            }

            _context.Requests.Remove(request);
            await _context.SaveChangesAsync();

            return true;
        }
        catch (Exception ex)
        {
            Log.Error(ex.Message);
            return false;
        }
    }

    public async Task<RequestModel> GetByIdAsync(string id)
    {
        try
        {
            var request = await _context.Requests.FirstOrDefaultAsync(x => x.Id.Equals(id));

            if (request is null)
            {
                Log.Error($"Request: {id} dont exist");
                return null!;
            }

            return request!;
        }
        catch (Exception ex)
        {
            Log.Error(ex.Message);
            return null!;
        }
    }

    public async Task<string[]> GetIdsAsync()
    {
        var requests = await _context.Requests.OrderByDescending(x => x.Created).Select(x => x.Id).ToArrayAsync();
        return requests;
    }

    public async Task<string[]> GetByUserIdAsync(string userId)
    {
        var requests = await _context.Requests.Where(x => x.OwnerId.Equals(userId)).OrderByDescending(x => x.Created).Select(x => x.Id).ToArrayAsync();
        return requests;
    }

    public async Task<bool> UpdateAsync(RequestModel request)
    {
        try
        {
            var Dbrequest = await _context.Requests.AsNoTracking().FirstOrDefaultAsync(x => x.Id.Equals(request.Id));

            if (Dbrequest is null)
            {
                Log.Error($"Request: {request.Id} dont exist");
                return false;
            }

            _context.Requests.Update(request);
            await _context.SaveChangesAsync();

            return true;
        }
        catch (Exception ex)
        {
            Log.Error(ex.Message);
            return false;
        }
    }

    public async Task<GetFullResponse> GetFullByIdAsync(string id)
    {
        try
        {
            var request = await _context.Requests.FirstOrDefaultAsync(x => x.Id.Equals(id));
            if (request is null)
            {
                Log.Error($"Request: {id} dont exist");
                return null!;
            }
            
            // get Tag IDs from RequestTags
            var requestTags = await _context.RequestTags.Where(rt => rt.RequestId!.Equals(id)).ToArrayAsync();

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

            var tagsArray = tags.ToArray();

            // Benötigt ein GetFullResponse Model

            return new GetFullResponse(request, tagsArray, projectTitle, owner, file); ;
        }
        catch (Exception ex)
        {
            Log.Error(ex.Message);
            return null!;
        }
    }
}
