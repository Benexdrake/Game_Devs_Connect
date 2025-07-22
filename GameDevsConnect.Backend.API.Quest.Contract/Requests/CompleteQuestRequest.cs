namespace GameDevsConnect.Backend.API.Quest.Contract.Requests;

public class CompleteQuestRequest
{
    public string QuestId { get; set; }
    public string FileId { get; set; }
    public string OwnerId { get; set; }
    public string Message { get; set; }
}
