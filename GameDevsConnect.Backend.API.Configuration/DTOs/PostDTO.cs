namespace GameDevsConnect.Backend.API.Configuration.DTOs;

public partial class PostDTO
{
    public string Id { get; set; } = null!;

    public string ParentId { get; set; } = string.Empty;

    public bool IsRequest { get; set; }

    public string? Message { get; set; }

    public string? Created { get; set; }

    public string? ProjectId { get; set; }

    public string? OwnerId { get; set; }

    public string? FileId { get; set; }

    public bool isDeleted { get; set; }
}
