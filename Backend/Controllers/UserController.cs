namespace Backend.Controllers;

[Route("user")]
[ApiController]
public class UserController(IUserRepository userRepository) : ControllerBase
{
    [HttpGet("all")]
    public async Task<ActionResult> GetUsersAsync()
    {
        var users = await userRepository.GetUsersAsync();

        return Ok(users);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult> GetUserAsync(string id)
    {
        var user = await userRepository.GetUserAsync(id);

        return Ok(user);
    }


    [HttpPost("add")]
    public async Task<ActionResult> AddUserAsync(User user)
    {
        if (user is null) return BadRequest("Where is the User?");

        var result = await userRepository.AddUserAsync(user);
        
        return Ok(result);
    }

    [HttpPut("update")]
    public async Task<ActionResult> UpdateUserAsync(User user)
    {
        if (user is null) return BadRequest("Where is the User?");
        
        var result = await userRepository.UpdateUserAsync(user);
       
        return Ok(result);
    }

    [HttpDelete("delete/{userId}")]
    public async Task<ActionResult> DeleteUserAsync(string userId)
    {
        var result = await userRepository.DeleteUserAsync(userId);

        return Ok(result);
    }
}
