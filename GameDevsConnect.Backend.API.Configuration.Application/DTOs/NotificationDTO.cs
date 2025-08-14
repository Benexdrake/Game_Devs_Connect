namespace GameDevsConnect.Backend.API.Configuration.Application.DTOs;
public partial class NotificationDTO
{
    public string Id { get; set; }

    public string PostId { get; set; }

    public int Type { get; set; }

    public string OwnerId { get; set; }

    public string UserId { get; set; }

    public bool Seen { get; set; }

    public string Created { get; set; }

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
