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

    [HttpGet("user/{userId}")]
    public async Task<ActionResult> GetRequestsByUserId(string userId)
    {
        var result = await requestRepository.GetRequestsByUserId(userId);

        return Ok(result);
    }

    [HttpGet("full/{id}")]
    public async Task<ActionResult> GetFullRequestById(int id, string userId)
    {
        var result = await requestRepository.getFullRequestById(id, userId);

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

    [HttpPost("liked")]
    public async Task<ActionResult> UpdatedLikeRequest(int requestId, string userId, bool liked)
    {
        var result = await requestRepository.LikesOnRequest(requestId, userId, liked);

        return Ok(result);
    }

    [HttpDelete("delete/{id}")]
    public async Task<ActionResult> DeleteRequest(int id)
    {
        var result = await requestRepository.DeleteRequest(id);

        return Ok(result);
    }
}
