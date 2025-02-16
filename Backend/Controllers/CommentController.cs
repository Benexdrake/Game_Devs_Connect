namespace Backend.Controllers;

[Route("comment")]
[ApiController]
public class CommentController(ICommentRepository repository) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult> GetCommentsById(int id)
    {
        var result = await repository.GetCommentByIdAsync(id);
        return Ok(result);
    }
}
