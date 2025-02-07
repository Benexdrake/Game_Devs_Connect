namespace Backend.Models;

public class ShortUser(string id, string username)
{
    public string Id { get; set; } = id;
    public string Username { get; set; } = username;
}
