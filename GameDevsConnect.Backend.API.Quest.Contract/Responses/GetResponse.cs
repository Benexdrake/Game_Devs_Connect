using GameDevsConnect.Backend.API.Configuration.Contract.Responses;

namespace GameDevsConnect.Backend.API.Quest.Contract.Responses;
public class GetResponse(string message, bool status, QuestDTO quest) : ApiResponse(message, status)
{
    public QuestDTO Quest { get; set; } = quest;
}
