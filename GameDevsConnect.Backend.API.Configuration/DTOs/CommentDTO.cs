namespace GameDevsConnect.Backend.API.Configuration.DTOs;

public partial class CommentDTO
{
    public string Id { get; set; } = null!;

    public string? Message { get; set; }

    public string? RequestId { get; set; }

    public string? FileId { get; set; }

    public string? OwnerId { get; set; }

    public string? Created { get; set; }

    public byte? Deleted { get; set; }
}
