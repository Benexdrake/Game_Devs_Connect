using GameDevsConnect.Backend.API.Configuration.Contract.Responses;

namespace GameDevsConnect.Backend.API.Tag.Contract.Responses;

public class GetTagsResponse(string message, bool status, TagDTO[] tags, string[] errors = default!)
{
    public ApiResponse Response { get; set; } = new ApiResponse(message, status, errors);
    public TagDTO[] Tags { get; set; } = tags;
}
