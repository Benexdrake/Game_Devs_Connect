namespace GameDevsConnect.Backend.Shared.Models;

public class AuthModel
{
    public string UserId { get; set; }
    public string Token { get; set; }
    public long Expires { get; set; }
}
