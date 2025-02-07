namespace Backend.Controllers;

[Route("[controller]")]
[ApiController]
public class RequestController(GDCDbContext context) : ControllerBase
{
    private readonly GDCDbContext _context = context;

    [HttpGet]
    public async Task<ActionResult> GetRequests()
    {
        var requests = await _context.Requests.ToListAsync();

        return Ok(requests);
    }

    [HttpGet]
    public async Task<ActionResult> GetRequestByID(string id)
    {
        var request = await _context.Requests.FirstOrDefaultAsync(x => x.Id.Equals(id));

        return Ok(request);
    }

    [HttpPost]
    public async Task<ActionResult> AddRequest(Request request)
    {
        var DbRequest = await _context.Requests.FirstOrDefaultAsync(x => x.Id.Equals(request.Id));

        if (DbRequest is not null) return BadRequest();

        await _context.Requests.AddAsync(request);
        await _context.SaveChangesAsync();

        return Ok(request);
    }

    [HttpPut]
    public async Task<ActionResult> UpdateRequest(Request request)
    {
        var Dbrequest = await _context.Requests.FirstOrDefaultAsync(x => x.Id.Equals(request));
        
        // Update

        return Ok(request);
    }

    [HttpDelete]
    public async Task<ActionResult> DeleteRequest(string id)
    {
        var request = await _context.Requests.FirstOrDefaultAsync(x => x.Id.Equals(id));

        if (request is null) return BadRequest();

        _context.Requests.Remove(request);
        await _context.SaveChangesAsync();

        return Ok();
    }
}
