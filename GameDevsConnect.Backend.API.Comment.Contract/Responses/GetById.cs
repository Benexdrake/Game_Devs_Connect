using GameDevsConnect.Backend.Shared.Models;

namespace GameDevsConnect.Backend.API.Comment.Contract.Responses;

public class GetById(string message, bool status, CommentModel comment)
{
    public string Message { get; set; } = message;
    public bool Status { get; set; } = status;
    public CommentModel Comment { get; set; } = comment;
}
