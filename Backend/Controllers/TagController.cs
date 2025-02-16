namespace Backend.Controllers;

[Route("tag")]
[ApiController]
public class TagController(ITagRepository repository) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult> GetTasks()
    {
        var result = await repository.GetTags();
        return Ok(result);
    }

    [HttpPost("add")]
    public async Task<ActionResult> AddTasks(Tag tag)
    {
        var result = await repository.AddTag(tag);
        return Ok(result);
    }

    [HttpPut("update")]
    public async Task<ActionResult> UpdateTasks(Tag tag)
    {
        var result = await repository.UpdateTag(tag);
        return Ok(result);
    }

    [HttpDelete("delete/{id}")]
    public async Task<ActionResult> DeleteTasks(int id)
    {
        var result = await repository.DeleteTag(id);
        return Ok(result);
    }

}
