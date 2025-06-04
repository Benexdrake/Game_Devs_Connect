using GameDevsConnect.Backend.Shared.Models;

namespace GameDevsConnect.Backend.API.Tag.Contract.Responses;

public class GetTagsResponse(string message, bool status, TagModel[] tags)
{
    public string Message { get; set; } = message;
    public bool Status { get; set; } = status;
    public TagModel[] Tags { get; set; } = tags;
}
