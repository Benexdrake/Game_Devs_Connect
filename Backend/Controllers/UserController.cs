namespace Backend.Controllers;

[Route("[controller]")]
[ApiController]
public class UserController(IUserRepository userRepository) : ControllerBase
{
    [HttpGet("all")]
    public async Task<ActionResult> GetUsersAsync()
    {
        var users = await userRepository.GetUsersAsync();

        return Ok(users);
    }

    [HttpGet("id/{id}")]
    public async Task<ActionResult> GetUserAsync(string id)
    {
        var user = await userRepository.GetUserAsync(id);
        if(user is not null)
            return Ok(user);
        return NotFound();
    }

    [HttpGet("short")]
    public async Task<ActionResult> GetShortUsersAsync()
    {
        var users = await userRepository.GetShortUsersAsync();
        return Ok(users);
    }

    [HttpPost("add")]
    public async Task<ActionResult> AddUserAsync(User user)
    {
        if (user is null) return BadRequest();

        var result = await userRepository.AddUserAsync(user);
        if(result)
            return Ok(result);
        return BadRequest();
    }

    [HttpPut("update")]
    public async Task<ActionResult> UpdateUserAsync(User user)
    {
        if (user is null) return BadRequest("Where is the User?");
        
        var result = await userRepository.UpdateUserAsync(user);
        if (result)
            return Ok(result);
        return NotFound();
    }

    [HttpDelete("delete/{userId}")]
    public async Task<ActionResult> DeleteUserAsync(string userId)
    {
        var result = await userRepository.DeleteUserAsync(userId);
        if (result)
            return Ok(result);
        return NotFound();
    }
}
