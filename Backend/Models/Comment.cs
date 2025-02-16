namespace Backend.Models;

public partial class Comment
{
    public int Id { get; set; }

    public string Message { get; set; } = string.Empty;

    public string Filename { get; set; } = string.Empty;

    public int Parentid { get; set; }
    public bool Deleted { get; set; }
}
