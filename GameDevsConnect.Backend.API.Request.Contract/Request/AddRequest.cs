using GameDevsConnect.Backend.Shared.Models;

namespace GameDevsConnect.Backend.API.Request.Contract.Request;

public class AddRequest(RequestModel? request, TagModel[]? tags)
{
    public RequestModel? Request { get; set; } = request;
    public TagModel[]? Tags { get; set; } = tags;
}
