namespace Backend.Models;

public class Request
{
    public string Id { get; set; } = string.Empty;
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string FileUrl { get; set; } = string.Empty;
    public DateTimeOffset Created { get; set; }
    public string ProjectId { get; set; } = string.Empty;
    public string UserId { get; set; } = string.Empty;
}