namespace Backend.Controllers;

[Route("tag")]
[ApiController]
public class TagController(ITagRepository repository) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult> GetTags()
    {
        var result = await repository.GetTags();
        return Ok(result);
    }

    [HttpGet("{requestId}")]
    public async Task<ActionResult> GetTagsByRequestId(int requestId)
    {
        var result = await repository.GetTagsByRequestId(requestId);
        return Ok(result);
    }

    [HttpPost("add")]
    public async Task<ActionResult> AddTags(Tag tag)
    {
        var result = await repository.AddTag(tag);
        return Ok(result);
    }

    [HttpPut("update")]
    public async Task<ActionResult> UpdateTags(Tag tag)
    {
        var result = await repository.UpdateTag(tag);
        return Ok(result);
    }

    [HttpDelete("delete/{id}")]
    public async Task<ActionResult> DeleteTags(int id)
    {
        var result = await repository.DeleteTag(id);
        return Ok(result);
    }

}
