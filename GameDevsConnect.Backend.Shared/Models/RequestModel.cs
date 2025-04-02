namespace GameDevsConnect.Backend.Shared.Models;

public partial class RequestModel
{
    public int Id { get; set; }

    public string Title { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;

    public int FileId { get; set; }

    public string Created { get; set; } = string.Empty;

    public string ProjectId { get; set; } = string.Empty;

    public string OwnerId { get; set; } = string.Empty;
}
