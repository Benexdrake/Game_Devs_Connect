namespace GameDevsConnect.Backend.API.Configuration.Application.DTOs;
public partial class NotificationDTO
{
    public string Id { get; set; } = string.Empty;

    public string PostId { get; set; } = string.Empty;

    public int Type { get; set; }

    public string OwnerId { get; set; } = string.Empty;

    public string UserId { get; set; } = string.Empty;

    public bool Seen { get; set; }

    public string Created { get; set; } = string.Empty;

    public NotificationDTO(string id, string postId, int type, string ownerId, string userId, bool seen, string created)
    {
        Id = id;
        PostId = postId;
        Type = type;
        OwnerId = ownerId;
        UserId = userId;
        Seen = seen;
        Created = created;
    }

    public NotificationDTO() { }
}
