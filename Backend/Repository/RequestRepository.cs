namespace Backend.Repository;

public class RequestRepository(GdcContext context) : IRequestRepository
{
    private readonly GdcContext _context = context;
    public async Task<APIResponse> AddRequest(RequestTags rt)
    {
        try
        {
            var DbRequest = await _context.Requests.FirstOrDefaultAsync(x => x.Id.Equals(rt.Request.Id));

            if (DbRequest is not null) return new APIResponse("Request Exists in DB",false, new { });

            await _context.Requests.AddAsync(rt.Request);
            _context.SaveChanges();

            // Deleting all RequestTag and saving new
            var requestTags = _context.RequestTags.Where(x => x.RequestId.Equals(rt.Request.Id)).ToList();

            await _context.RequestTags.Where(x => x.RequestId.Equals(rt.Request.Id)).ExecuteDeleteAsync();

            

            foreach (var tag in rt.Tags)
            {
                var requestTag = new RequestTag
                {
                    RequestId = rt.Request.Id,
                    TagId = tag.Id
                };


                _context. RequestTags.Add(requestTag);
            }
            await _context.SaveChangesAsync();
            

            return new APIResponse("Request saved in DB", true, rt.Request.Id);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return new APIResponse(ex.Message, false, new { });
        }
    }

    public async Task<APIResponse> DeleteRequest(int id)
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
            Console.WriteLine(ex.Message);
            return new APIResponse(ex.Message, false, new { });
        }
    }

    public async Task<APIResponse> GetFilesByRequestId(int id)
    {
        var fileIds = await _context.Comments.Where(x => x.ParentId == id).Where(x => x.FileId != 0).Select(x => x.FileId).ToListAsync();

        return new APIResponse("", true, fileIds);
    }

    public async Task<APIResponse> GetRequestById(int id)
    {
        try
        {
            var request = await _context.Requests.FirstOrDefaultAsync(x => x.Id.Equals(id));

            if (request is null) return new APIResponse("Request dont exist", false, new { });

           
            return new APIResponse("", true, request);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return new APIResponse(ex.Message, false, new { });
        }
    }

    public async Task<IEnumerable<int>> GetRequests()
    {
        var requests = await _context.Requests.OrderByDescending(x => x.Created).ToListAsync();
        return requests.Select(x => x.Id).ToList();
    }

    public async Task<APIResponse> UpdateRequest(Request request)
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
            Console.WriteLine(ex.Message);
            return new APIResponse(ex.Message, false, new { });
        }
    }
}
