namespace Backend.Models;

public class Notification
{
    public string Id { get; set; } = string.Empty;
    public int RequestId { get; set; }
    public int Type { get; set; }
    public string OwnerId { get; set; } = string.Empty;
    public string UserId { get; set; } = string.Empty;
    public string Seen { get; set; } = string.Empty;
}
