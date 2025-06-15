namespace GameDevsConnect.Backend.API.Configuration.Models;

public partial class RequestModel
{
    public string Id { get; set; } = null!;

    public string? Title { get; set; }

    public string? Description { get; set; }

    public string? Created { get; set; }

    public string? ProjectId { get; set; }

    public string? OwnerId { get; set; }

    public string? FileId { get; set; }
}
