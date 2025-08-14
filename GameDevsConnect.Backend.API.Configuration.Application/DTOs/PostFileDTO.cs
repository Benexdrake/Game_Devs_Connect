namespace GameDevsConnect.Backend.API.Configuration.Application.DTOs;

public class PostFileDTO
{
    public string PostId { get; set; } = string.Empty;
    public string FileId { get; set; } = string.Empty;

    public PostFileDTO(string postId, string fileId)
    {
        PostId = postId;
        FileId = fileId;
    }

    public PostFileDTO() { }
}
