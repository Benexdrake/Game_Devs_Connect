namespace GameDevsConnect.Backend.API.Configuration.Application.DTOs;

public class FavoriteQuestDTO
{
    public string QuestId { get; set; } = string.Empty;
    public string UserId { get; set; } = string.Empty;

    public FavoriteQuestDTO(string questId, string userId)
    {
        QuestId = questId;
        UserId = userId;
    }

    public FavoriteQuestDTO() { }
}
