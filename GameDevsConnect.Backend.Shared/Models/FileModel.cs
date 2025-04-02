namespace GameDevsConnect.Backend.Shared.Models;

public class FileModel
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public int Size { get; set; }
    public string Created { get; set; } = string.Empty;
    public string OwnerId { get; set; } = string.Empty;
}
