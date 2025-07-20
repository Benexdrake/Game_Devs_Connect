namespace GameDevsConnect.Backend.API.Quest.Contract.Responses;
public class GetResponse(string message, bool status, QuestDTO quest, bool favoritedQuest) : ApiResponse(message, status)
{
    public QuestDTO Quest { get; set; } = quest;
    public bool FavoritedQuest { get; set; } = favoritedQuest;
}
