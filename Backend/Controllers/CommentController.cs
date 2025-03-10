namespace Backend.Controllers;

[Route("comment")]
[ApiController]
public class CommentController(ICommentRepository repository) : ControllerBase
{
    [HttpGet("{parentId}")]
    public async Task<ActionResult> GetCommentsById(int parentId)
    {
        var result = await repository.GetCommentsByParentsIdAsync(parentId);
        return Ok(result);
    }

    [HttpGet("id/{id}")]
    public async Task<ActionResult> GetComment(int id)
    {
        var result = await repository.GetCommentByIdAsync(id);
        return Ok(result);
    }

    [HttpGet("count/{parentId}")]
    public async Task<ActionResult> GetCommentsCount(int parentId)
    {
        var result = await repository.GetCommentsCountByParentIdAsync(parentId);
        return Ok(result);
    }

    [HttpPost("add")]
    public async Task<ActionResult> AddComment(Comment comment)
    {
        var result = await repository.AddCommentAsync(comment);
        return Ok(result);
    }

    [HttpPut("update")]
    public async Task<ActionResult> UpdateComment(Comment comment)
    {
        var result = await repository.UpdateCommentAsync(comment);
        return Ok(result);
    }

    [HttpDelete("delete/{id}")]
    public async Task<ActionResult> DeleteComment(int id)
    {
        var result = await repository.DeleteCommentByIdAsync(id);
        return Ok(result);
    }
}
