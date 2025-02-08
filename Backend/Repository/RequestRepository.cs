
using Microsoft.EntityFrameworkCore;

namespace Backend.Repository;

public class RequestRepository(GDCDbContext context) : IRequestRepository
{
    private readonly GDCDbContext _context = context;
    public async Task<bool> AddRequest(Request request)
    {
        try
        {
            var DbRequest = await _context.Requests.FirstOrDefaultAsync(x => x.Id.Equals(request.Id));

            if (DbRequest is not null) return false;

            await _context.Requests.AddAsync(request);
            await _context.SaveChangesAsync();

            return true;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return false;
        }
    }

    public async Task<bool> DeleteRequest(string id)
    {
        try
        {
            var request = await _context.Requests.FirstOrDefaultAsync(x => x.Id.Equals(id));

            if (request is null) return false;

            _context.Requests.Remove(request);
            await _context.SaveChangesAsync();

            return true;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return false;
        }
    }

    public async Task<Request> GetRequestById(string id)
    {
        return await _context.Requests.FirstOrDefaultAsync(x => x.Id.Equals(id));
    }

    public async Task<IEnumerable<Request>> GetRequests()
    {
        return await _context.Requests.ToListAsync();
    }

    public async Task<bool> UpdateRequest(Request request)
    {
        try
        {
            var Dbrequest = await _context.Requests.FirstOrDefaultAsync(x => x.Id.Equals(request.Id));

            if (Dbrequest is null) return false;

            // Update Request
            Dbrequest.Title = request.Title;
            Dbrequest.Description = request.Description;
            Dbrequest.FileUrl = request.FileUrl;

            await _context.SaveChangesAsync();

            return true;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return false;
        }
    }
}
