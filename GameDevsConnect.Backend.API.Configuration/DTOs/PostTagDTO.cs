namespace GameDevsConnect.Backend.API.Configuration.DTOs;

public partial class PostTagDTO(string? postId, int? tagId)
{
    public string? PostId { get; set; } = postId;
    public int? TagId { get; set; } = tagId;
}
