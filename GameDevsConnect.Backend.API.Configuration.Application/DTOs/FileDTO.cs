namespace GameDevsConnect.Backend.API.Configuration.Application.DTOs;

public partial class FileDTO
{
    public string Id { get; set; } = string.Empty;

    public string Url { get; set; } = string.Empty;

    public string Type { get; set; } = string.Empty;
    public string Extension { get; set; } = string.Empty;

    public int Size { get; set; }

    public DateTime? Created { get; set; }

    public string OwnerId { get; set; } = string.Empty;

    public FileDTO(string id, string url, string type, string extension, int size, DateTime? created, string ownerId)
    {
        Id = id;
        Url = url;
        Type = type;
        Extension = extension;
        Size = size;
        Created = created;
        OwnerId = ownerId;
    }

    public FileDTO() { }
}
