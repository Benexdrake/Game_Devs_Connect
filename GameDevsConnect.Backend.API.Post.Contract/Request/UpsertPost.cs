namespace GameDevsConnect.Backend.API.Post.Contract.Request;

public class UpsertPost(PostDTO? post, TagDTO[]? tags)
{
    public PostDTO? Post { get; set; } = post;
    public TagDTO[]? Tags { get; set; } = tags;
}
