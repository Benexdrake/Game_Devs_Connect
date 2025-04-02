namespace GameDevsConnect.Backend.Shared.Models;

public class ElementModel
{
    public string Id { get; set; } = null!;

    public int? Elementtype { get; set; }

    public string? Content { get; set; }

    public string? Config { get; set; }

    public int? Nr { get; set; }

    public string? Projectid { get; set; }
}
