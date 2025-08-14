namespace GameDevsConnect.Backend.API.Configuration.Application.DTOs;

public class QuestFileDTO
{
    public string QuestId { get; set; } = string.Empty;
    public string FileId { get; set; } = string.Empty;
    public string OwnerId { get; set; } = string.Empty;
    public string Message { get; set; } = string.Empty;

    public QuestFileDTO(string questId, string fileId, string ownerId, string message)
    {
        QuestId = questId;
        FileId = fileId;
        OwnerId = ownerId;
        Message = message;
    }

    public QuestFileDTO() { }
}
