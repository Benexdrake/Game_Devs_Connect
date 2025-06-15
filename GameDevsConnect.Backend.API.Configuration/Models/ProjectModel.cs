namespace GameDevsConnect.Backend.API.Configuration.Models;

public partial class ProjectModel
{
    public string Id { get; set; } = null!;

    public string? Title { get; set; }

    public string? Description { get; set; }

    public string? OwnerId { get; set; }
}
