namespace Backend.Models;

public class RequestTags
{

    public Request Request { get; set; }
    public Tag[] Tags { get; set; } = [];
}
