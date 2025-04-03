namespace GameDevsConnect.Backend.Middleware;
public class Auth
{
    public string UserId { get; set; }
    public string Token { get; set; }
    public long Expires { get; set; }
}
