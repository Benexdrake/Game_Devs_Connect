namespace GameDevsConnect.Backend.API.Quest.Contract.Responses;
public class GetResponse(string message, bool status, QuestDTO quest, bool favoritedQuest, string[] errors = default!)
{
    public ApiResponse Response { get; set; } = new ApiResponse(message, status, errors);
    public QuestDTO Quest { get; set; } = quest;
    public bool FavoritedQuest { get; set; } = favoritedQuest;
}
