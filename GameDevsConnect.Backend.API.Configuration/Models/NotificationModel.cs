namespace GameDevsConnect.Backend.API.Configuration.Models;
public partial class NotificationModel
{
    public string Id { get; set; }

    public string? RequestId { get; set; }

    public int? Type { get; set; }

    public string? OwnerId { get; set; }

    public string? UserId { get; set; }

    public bool Seen { get; set; }

    public string? Created { get; set; }
}
