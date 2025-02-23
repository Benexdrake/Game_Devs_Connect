namespace Backend.Models;
public class RequestLikes
{
    public string Id { get; set; } = string.Empty;
    public int RequestId { get; set; }
    public string UserId { get; set; } = string.Empty;
}
