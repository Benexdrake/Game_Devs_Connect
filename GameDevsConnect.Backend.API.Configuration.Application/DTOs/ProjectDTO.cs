namespace GameDevsConnect.Backend.API.Configuration.Application.DTOs;

public partial class ProjectDTO
{
    public string Id { get; set; } = string.Empty;
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string OwnerId { get; set; } = string.Empty;

    public ProjectDTO() {}

    public ProjectDTO(string id, string title, string description, string ownerId)
    {
        Id = id;
        Title = title;
        Description = description;
        OwnerId = ownerId;
    }
}
