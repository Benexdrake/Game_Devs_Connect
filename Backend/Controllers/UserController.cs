namespace Backend.Controllers;

[Route("[controller]")]
[ApiController]
public class UserController(UserRepository userRepository) : ControllerBase
{
    private readonly UserRepository _userRepository = userRepository;

    [HttpGet]
    public async Task<ActionResult> GetUsersAsync()
    {
        var users = await _userRepository.GetUsersAsync();

        return Ok(users);
    }

    [HttpGet]
    public async Task<ActionResult> GetUserAsync(string id)
    {
        var user = await _userRepository.GetUserAsync(id);

        return Ok(user);
    }

    [HttpGet]
    public async Task<ActionResult> GetShortUsersAsync()
    {
        var users = await _userRepository.GetShortUsersAsync();

        return Ok(users);
    }

    [HttpPost]
    public async Task<ActionResult> AddUserAsync(User user)
    {
        if (user is null) return BadRequest();

        var result = await _userRepository.AddUserAsync(user);

        return Ok(result);
    }

    [HttpPut]
    public async Task<ActionResult> UpdateUserAsync(User user)
    {
        if (user is null) return BadRequest("Where is the User?");
        
        var result = await _userRepository.UpdateUserAsync(user);

        return Ok(result);
    }

    [HttpDelete]
    public async Task<ActionResult> DeleteUserAsync(string userId)
    {
        var result = await _userRepository.DeleteUserAsync(userId);

        return Ok(result);
    }
}
