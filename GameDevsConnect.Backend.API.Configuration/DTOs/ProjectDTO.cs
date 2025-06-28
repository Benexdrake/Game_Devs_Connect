namespace GameDevsConnect.Backend.API.Configuration.DTOs;

public partial class ProjectDTO
{
    public string Id { get; set; } = null!;

    public string? Title { get; set; }

    public string? Description { get; set; }

    public string? OwnerId { get; set; }
}
