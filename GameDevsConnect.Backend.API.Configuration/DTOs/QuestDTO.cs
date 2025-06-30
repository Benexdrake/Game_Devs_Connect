namespace GameDevsConnect.Backend.API.Configuration.DTOs;

public class QuestDTO
{
    public string? Id { get; set; }
    public string? PostId { get; set; }
    public string? OwnerId { get; set; }
    public int Difficulty { get; set; }
    public string? Title { get; set; }
    public string? Description { get; set; }
}
