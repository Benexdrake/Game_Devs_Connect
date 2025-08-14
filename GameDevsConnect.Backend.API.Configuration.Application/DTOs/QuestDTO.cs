namespace GameDevsConnect.Backend.API.Configuration.Application.DTOs;

public class QuestDTO
{
    public string Id { get; set; } = string.Empty;
    public string PostId { get; set; } = string.Empty;
    public string OwnerId { get; set; } = string.Empty;
    public int Difficulty { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;

    public QuestDTO() {}

    public QuestDTO(string id, string postId, string ownerId, int difficulty, string title, string description)
    {
        Id = id;
        PostId = postId;
        OwnerId = ownerId;
        Difficulty = difficulty;
        Title = title;
        Description = description;
    }
}
