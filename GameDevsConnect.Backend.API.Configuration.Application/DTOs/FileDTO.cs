namespace GameDevsConnect.Backend.API.Configuration.Application.DTOs;

public partial class FileDTO
{
    public string? Id { get; set; }

    public string? Url { get; set; }

    public string? Type { get; set; }
    public string? Extension { get; set; }

    public int? Size { get; set; }

    public DateTime? Created { get; set; }

    public string? OwnerId { get; set; }
}
