namespace GameDevsConnect.Backend.API.Post.Contract.Request;

public class AddPost(PostDTO? request, TagDTO[]? tags)
{
    public PostDTO? Request { get; set; } = request;
    public TagDTO[]? Tags { get; set; } = tags;
}
