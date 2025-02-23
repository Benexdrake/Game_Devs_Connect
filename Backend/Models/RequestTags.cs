namespace Backend.Models;

public partial class RequestTags
{
    public Request Request { get; set; } = new();

    public Tag[] Tags { get; set; } = [];
}
