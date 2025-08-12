namespace GameDevsConnect.Backend.API.Configuration.Application.DTOs;

public class QuestDTO
{
    public string? Id { get; set; }
    public string? PostId { get; set; }
    public string? OwnerId { get; set; }
    public int Difficulty { get; set; }
    public string? Title { get; set; }
    public string? Description { get; set; }

    public QuestDTO() {}

    public QuestDTO(string? id, string? postId, string? ownerId, int difficulty, string? title, string? description)
    {
        Id = id;
        PostId = postId;
        OwnerId = ownerId;
        Difficulty = difficulty;
        Title = title;
        Description = description;
    }
}
