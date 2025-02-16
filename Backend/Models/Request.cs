namespace Backend.Models;

public partial class Request
{
    public int Id { get; set; }

    public string Title { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;

    public string Fileurl { get; set; } = string.Empty;

    public string Created { get; set; } = string.Empty;

    public string ProjectId { get; set; } = string.Empty;

    public string UserId { get; set; } = string.Empty;
}
