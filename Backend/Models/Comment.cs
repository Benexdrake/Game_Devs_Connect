namespace Backend.Models;

public partial class Comment
{
    public int Id { get; set; }
    public string Message { get; set; } = string.Empty;
    public int FileId { get; set; }
    public int ParentId { get; set; }
    public string OwnerId { get; set; } = string.Empty;
    public string Created { get; set; } = string.Empty;
    public bool Deleted { get; set; }
}
