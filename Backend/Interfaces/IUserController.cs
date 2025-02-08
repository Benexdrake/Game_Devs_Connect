namespace Backend.Interfaces;

public interface IUserController
{
    Task<ActionResult> GetUsersAsync();
    Task<ActionResult> GetUserAsync(string id);
    Task<ActionResult> GetShortUsersAsync();
    Task<ActionResult> AddUserAsync(User user);
    Task<ActionResult> UpdateUserAsync(User user);
    Task<ActionResult> DeleteUserAsync(string id);
}
