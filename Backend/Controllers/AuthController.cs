namespace Backend.Controllers;

[Route("auth")]
[ApiController]
public class AuthController(IAuthRepository repository) : ControllerBase
{
    [HttpGet("{id}")]
    public async Task<ActionResult> Get(string id)
    {
        var result = await repository.Get(id);
        return Ok(result);
    }

    [HttpPost("add")]
    public async Task<ActionResult> Add(Auth auth)
    {
        var result = await repository.Add(auth);
        return Ok(result);
    }

    [HttpPut("update")]
    public async Task<ActionResult> Update(Auth auth)
    {
        var result = await repository.Update(auth);
        return Ok(result);
    }

    [HttpDelete("delete/{id}")]
    public async Task<ActionResult> Delete(string id)
    {
        var result = await repository.Delete(id);
        return Ok(result);
    }

}
