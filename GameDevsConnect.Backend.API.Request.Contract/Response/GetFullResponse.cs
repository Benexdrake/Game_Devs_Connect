using GameDevsConnect.Backend.Shared.Models;

namespace GameDevsConnect.Backend.API.Request.Contract.Response;

public class GetFullResponse(RequestModel? request, TagModel[]? tags, string projectTitle, UserModel? owner, FileModel? file)
{
    public RequestModel? Request { get; set; } = request;
    public TagModel[]? Tags { get; set; } = tags;
    public string ProjectTitle { get; set; } = projectTitle;
    public UserModel? Owner { get; set; } = owner;
    public FileModel? File { get; set; } = file;
}
