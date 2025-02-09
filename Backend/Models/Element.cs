namespace Backend.Models;

public class Element
{
    public string Id { get; set; } = string.Empty;
    public ElementType Type { get; set; }
    public string Content { get; set; } = string.Empty;
    public string Config { get; set; } = string.Empty;
    public string ProjectId { get; set; } = string.Empty;
}
