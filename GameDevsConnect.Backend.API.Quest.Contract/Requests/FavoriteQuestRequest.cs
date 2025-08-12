namespace GameDevsConnect.Backend.API.Quest.Contract.Requests;

public class FavoriteQuestRequest
{
    public string QuestId { get; set; } = string.Empty;
    public string UserId { get; set; } = string.Empty;
}
