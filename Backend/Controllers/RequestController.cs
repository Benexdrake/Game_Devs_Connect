namespace Backend.Controllers;

[Route("request")]
[ApiController]
public class RequestController(IRequestRepository requestRepository) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult> GetRequests()
    {
        var result = await requestRepository.GetRequests();

        return Ok(result);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult> GetRequestById(int id)
    {
        var result = await requestRepository.GetRequestById(id);

        return Ok(result);
    }

    [HttpGet("check/{id}")]
    public async Task<ActionResult> GetRequestCheck(int id)
    {
        var result = await requestRepository.GetRequestById(id);
        result.Data = new { };

        return Ok(result);
    }

    [HttpGet("files/{id}")]
    public async Task<ActionResult> GetFilesByRequestId(int id)
    {
        var result = await requestRepository.GetFilesByRequestId(id);

        return Ok(result);
    }

    [HttpPost("add")]
    public async Task<ActionResult> AddRequest(RequestTags rt)
    {
        var result = await requestRepository.AddRequest(rt);
        return Ok(result);
    }

    [HttpPut("update")]
    public async Task<ActionResult> UpdateRequest(Request request)
    {
        var result = await requestRepository.UpdateRequest(request);

        return Ok(result);
    }

    [HttpDelete("delete/{id}")]
    public async Task<ActionResult> DeleteRequest(int id)
    {
        var result = await requestRepository.DeleteRequest(id);

        return Ok(result);
    }
}
