namespace Backend.Controllers;

[Route("[controller]")]
[ApiController]
public class RequestController(IRequestRepository requestRepository) : ControllerBase
{
    [HttpGet("all")]
    public async Task<ActionResult> GetRequests()
    {
        var requests = await requestRepository.GetRequests();

        return Ok(requests);
    }

    [HttpGet("id/{id}")]
    public async Task<ActionResult> GetRequestById(string id)
    {
        var request = await requestRepository.GetRequestById(id);

        return Ok(request);
    }

    [HttpPost("add")]
    public async Task<ActionResult> AddRequest(Request request)
    {
        var result = await requestRepository.AddRequest(request);

        return Ok(result);
    }

    [HttpPut("update")]
    public async Task<ActionResult> UpdateRequest(Request request)
    {
        var result = await requestRepository.UpdateRequest(request);

        return Ok(result);
    }

    [HttpDelete("delete/{id}")]
    public async Task<ActionResult> DeleteRequest(string id)
    {
        var result = await requestRepository.DeleteRequest(id);

        return Ok(result);
    }
}
