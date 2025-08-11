namespace GameDevsConnect.Backend.API.Configuration.Application.DTOs;

public partial class TagDTO
{
    public string Tag { get; set; } = string.Empty;
    public string Type { get; set; } = string.Empty;

    public TagDTO() {}

    public TagDTO(string tag, string type)
    {
        Tag = tag;
        Type = type;
    }
}
