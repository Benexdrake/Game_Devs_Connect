using GameDevsConnect.Backend.Shared.Models;
using GameDevsConnect.Backend.Shared.Responses;

namespace GameDevsConnect.Backend.API.Tag.Contract.Responses;

public class GetTagsResponse(string message, bool status, TagModel[] tags) : ApiResponse(message, status)
{
    public TagModel[] Tags { get; set; } = tags;
}
