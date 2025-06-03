namespace GameDevsConnect.Backend.Shared.Models;

public partial class RequestTag(string? requestId, int? tagId)
{
    public string? RequestId { get; set; } = requestId;
    public int? TagId { get; set; } = tagId;
}
