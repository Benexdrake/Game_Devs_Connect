using GameDevsConnect.Backend.Shared.Models;
using GameDevsConnect.Backend.Shared.Responses;

namespace GameDevsConnect.Backend.API.Request.Contract.Response;

public class GetFullResponse(string message, bool status, RequestModel? request, TagModel[]? tags, string projectTitle, UserModel? owner, FileModel? file) : ApiResponse(message, status)
{
    public RequestModel? Request { get; set; } = request;
    public TagModel[]? Tags { get; set; } = tags;
    public string ProjectTitle { get; set; } = projectTitle;
    public UserModel? Owner { get; set; } = owner;
    public FileModel? File { get; set; } = file;
}
