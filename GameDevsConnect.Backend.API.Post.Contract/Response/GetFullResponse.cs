using GameDevsConnect.Backend.API.Configuration.Application.DTOs;
using GameDevsConnect.Backend.API.Configuration.Contract.Responses;

namespace GameDevsConnect.Backend.API.Post.Contract.Response;

public class GetFullResponse(string message, bool status, PostDTO? post, TagDTO[]? tags, string projectTitle, UserDTO? owner, FileDTO? file) : ApiResponse(message, status)
{
    public PostDTO? Post { get; set; } = post;
    public TagDTO[]? Tags { get; set; } = tags;
    public string ProjectTitle { get; set; } = projectTitle;
    public UserDTO? Owner { get; set; } = owner;
    public FileDTO? File { get; set; } = file;
}
