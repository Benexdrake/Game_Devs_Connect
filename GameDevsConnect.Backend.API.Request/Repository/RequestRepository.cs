namespace GameDevsConnect.Backend.API.Request.Repository;

public class RequestRepository(RequestDBContext context) : IRequestRepository
{
    private readonly RequestDBContext _context = context;

    public async Task<APIResponse> AddAsync(RequestModel request)
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

    public async Task<APIResponse> DeleteAsync(int id)
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

    public async Task<APIResponse> GetByIdAsync(int id)
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
}
