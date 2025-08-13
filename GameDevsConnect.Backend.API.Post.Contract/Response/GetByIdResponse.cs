namespace GameDevsConnect.Backend.API.Post.Contract.Response;
public class GetByIdResponse(string message, bool status, PostDTO? post, string[] errors = default!)
{
    public ApiResponse Response { get; set; } = new ApiResponse(message, status, errors);
    public PostDTO? Post { get; set; } = post;
}
