namespace GameDevsConnect.Backend.API.Comment.Contract.Responses;

public class GetById(string message, bool status, CommentModel comment) : ApiResponse(message, status)
{
    public CommentModel Comment { get; set; } = comment;
}
