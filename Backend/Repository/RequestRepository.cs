
using Microsoft.EntityFrameworkCore;

namespace Backend.Repository;

public class RequestRepository(GDCDbContext context) : IRequestRepository
{
    private readonly GDCDbContext _context = context;
    public async Task<APIResponse> AddRequest(Request request)
    {
        try
        {
            var DbRequest = await _context.Requests.FirstOrDefaultAsync(x => x.Id.Equals(request.Id));

            if (DbRequest is not null) return new APIResponse("Request Exists in DB",false);

            await _context.Requests.AddAsync(request);
            await _context.SaveChangesAsync();

            return new APIResponse("Request saved in DB", true);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return new APIResponse(ex.Message, false);
        }
    }

    public async Task<APIResponse> DeleteRequest(string id)
    {
        try
        {
            var request = await _context.Requests.FirstOrDefaultAsync(x => x.Id.Equals(id));

            if (request is null) return new APIResponse("Request dont exist", false);

            _context.Requests.Remove(request);
            await _context.SaveChangesAsync();

            return new APIResponse("Request got deleted", true);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return new APIResponse(ex.Message, false);
        }
    }

    public async Task<APIResponse> GetRequestById(string id)
    {
        var request = await _context.Requests.FirstOrDefaultAsync(x => x.Id.Equals(id));

        if (request is null) return new APIResponse("Request dont exist", false);

        var u = await _context.Users.FirstOrDefaultAsync(u => u.Id == request.UserId);

        if (u is not null)
        {
            var user = new {id=u.Id, username=u.Username, avatar=u.Avatar };
            return new APIResponse("", true, new { request, user });
        }
            return new APIResponse("", true, request);
    }

    public async Task<IEnumerable<string>> GetRequests()
    {
        var requests = await _context.Requests.ToListAsync();
        return requests.Select(x => x.Id).ToList();
    }

    public async Task<APIResponse> UpdateRequest(Request request)
    {
        try
        {
            var Dbrequest = await _context.Requests.FirstOrDefaultAsync(x => x.Id.Equals(request.Id));

            if (Dbrequest is null) return new APIResponse("Request dont exist", false);

            // Update Request
            Dbrequest.Title = request.Title;
            Dbrequest.Description = request.Description;
            Dbrequest.FileUrl = request.FileUrl;

            await _context.SaveChangesAsync();

            return new APIResponse("Request got updated", true);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return new APIResponse(ex.Message, false);
        }
    }
}
