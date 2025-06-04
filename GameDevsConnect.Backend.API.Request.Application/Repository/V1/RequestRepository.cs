namespace GameDevsConnect.Backend.API.Request.Application.Repository.V1;

public class RequestRepository(GDCDbContext context) : IRequestRepository
{
    private readonly GDCDbContext _context = context;

    public async Task<AddUpdateDeleteRequestResponse> AddAsync(AddRequest addRequest)
    {
        try
        {
            Message.Id = addRequest.Request!.Id;
            var requestDb = await _context.Requests.FirstOrDefaultAsync(x => x.Id.Equals(addRequest.Request!.Id));

            if (requestDb is not null)
            {
                Log.Error(Message.EXIST);
                return new AddUpdateDeleteRequestResponse(Message.EXIST,false);
            }

            await _context.Requests.AddAsync(addRequest.Request!);

            foreach(var tag in addRequest.Tags!)
            {
                _context.RequestTags.Add(new RequestTag(addRequest.Request!.Id, tag.Id));
            }

            await _context.SaveChangesAsync();

            Log.Information(Message.ADD);
            return new AddUpdateDeleteRequestResponse(Message.ADD, true);
        }
        catch (Exception ex)
        {
            Log.Error(ex.Message);
            return new AddUpdateDeleteRequestResponse(ex.Message, false);
        }
    }

    public async Task<AddUpdateDeleteRequestResponse> DeleteAsync(string id)
    {
        try
        {
            Message.Id = id;
            var request = await _context.Requests.FirstOrDefaultAsync(x => x.Id.Equals(id));

            if (request is null)
            {
                Log.Error(Message.NOTFOUND);
                return new AddUpdateDeleteRequestResponse(Message.NOTFOUND, false);
            }

            _context.Requests.Remove(request);
            await _context.SaveChangesAsync();

            Log.Information(Message.DELETE);
            return new AddUpdateDeleteRequestResponse(Message.DELETE, true);
        }
        catch (Exception ex)
        {
            Log.Error(ex.Message);
            return new AddUpdateDeleteRequestResponse(ex.Message, false);
        }
    }

    public async Task<GetByIdResponse> GetByIdAsync(string id)
    {
        try
        {
            var request = await _context.Requests.FirstOrDefaultAsync(x => x.Id.Equals(id));

            if (request is null)
            {
                Log.Error(Message.NOTFOUND);
                return new GetByIdResponse(Message.NOTFOUND, false, null!);
            }

            return new GetByIdResponse(null!, true, request);
        }
        catch (Exception ex)
        {
            Log.Error(ex.Message);
            return new GetByIdResponse(ex.Message, false, null!);
        }
    }

    public async Task<GetIdsResponse> GetIdsAsync()
    {
        try
        {
            var requests = await _context.Requests.OrderByDescending(x => x.Created).Select(x => x.Id).ToArrayAsync();
            return new GetIdsResponse(null!, true, requests);
        }
        catch (Exception ex)
        {
            Log.Error(ex.Message);
            return new GetIdsResponse(ex.Message, false, null!);
        }
    }

    public async Task<GetIdsResponse> GetByUserIdAsync(string userId)
    {
        try
        {
            var requests = await _context.Requests.Where(x => x.OwnerId!.Equals(userId)).OrderByDescending(x => x.Created).Select(x => x.Id).ToArrayAsync();
            return new GetIdsResponse(null!, true, requests);
        }
        catch (Exception ex)
        {
            Log.Error(ex.Message);
            return new GetIdsResponse(ex.Message, false, null!);
        }
    }

    public async Task<AddUpdateDeleteRequestResponse> UpdateAsync(RequestModel request)
    {
        try
        {
            var Dbrequest = await _context.Requests.AsNoTracking().FirstOrDefaultAsync(x => x.Id.Equals(request.Id));

            if (Dbrequest is null)
            {
                Log.Error(Message.NOTFOUND);
                return new AddUpdateDeleteRequestResponse(Message.NOTFOUND, false);
            }

            _context.Requests.Update(request);
            await _context.SaveChangesAsync();

            Log.Information(Message.UPDATE);
            return new AddUpdateDeleteRequestResponse(null!, true);
        }
        catch (Exception ex)
        {
            Log.Error(ex.Message);
            return new AddUpdateDeleteRequestResponse(ex.Message, false);
        }
    }

    public async Task<GetFullResponse> GetFullByIdAsync(string id)
    {
        try
        {
            var request = await _context.Requests.FirstOrDefaultAsync(x => x.Id.Equals(id));
            if (request is null)
            {
                Log.Error(Message.NOTFOUND);
                return new GetFullResponse(Message.NOTFOUND, false, null!, null!, null!, null!, null!);
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

            var owner = await _context.Users.FirstOrDefaultAsync(x => x.Id.Equals(request.OwnerId));

            var file = await _context.Files.FirstOrDefaultAsync(x => x.Id.Equals(request.FileId));

            var tagsArray = tags.ToArray();

            return new GetFullResponse(null!, true, request, tagsArray, projectTitle!, owner, file); ;
        }
        catch (Exception ex)
        {
            Log.Error(ex.Message);
            return new GetFullResponse(ex.Message, false, null!, null!, null!, null!, null!);
        }
    }
}
