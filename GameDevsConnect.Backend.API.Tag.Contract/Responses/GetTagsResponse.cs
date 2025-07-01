using GameDevsConnect.Backend.API.Configuration.Contract.Responses;

namespace GameDevsConnect.Backend.API.Tag.Contract.Responses;

public class GetTagsResponse(string message, bool status, TagDTO[] tags) : ApiResponse(message, status)
{
    public TagDTO[] Tags { get; set; } = tags;
}
