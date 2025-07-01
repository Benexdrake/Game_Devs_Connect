using GameDevsConnect.Backend.API.Configuration.Contract.Responses;

namespace GameDevsConnect.Backend.API.Post.Contract.Response;
public class GetByIdResponse(string message, bool status, PostDTO? post) : ApiResponse(message, status)
{
    public PostDTO? Post { get; set; } = post;
}
