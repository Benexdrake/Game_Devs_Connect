namespace GameDevsConnect.Backend.Shared.Models;

public class AuthModel
{
    public string UserId { get; set; } = string.Empty;
    public string Token { get; set; } = string.Empty;
    public long Expires { get; set; }
}
