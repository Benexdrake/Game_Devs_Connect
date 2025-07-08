namespace GameDevsConnect.Backend.API.Configuration.Application.DTOs;

public partial class PostTagDTO(string postId, string tag)
{
    public string PostId { get; set; } = postId;
    public string Tag { get; set; } = tag;
}
