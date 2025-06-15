namespace GameDevsConnect.Backend.API.Configuration.Models;

public partial class CommentModel
{
    public string Id { get; set; } = null!;

    public string? Message { get; set; }

    public string? RequestId { get; set; }

    public string? FileId { get; set; }

    public string? OwnerId { get; set; }

    public string? Created { get; set; }

    public byte? Deleted { get; set; }
}
