namespace GameDevsConnect.Backend.API.Post.Contract.Response;

public class GetFullResponse(string message, bool status, PostDTO? post, string[] questIdss, TagDTO[]? tags, string projectTitle, UserDTO? owner, FileDTO? file, int comments, int likes) : ApiResponse(message, status)
{
    public PostDTO? Post { get; set; } = post;
    public string[] QuestIdss { get; set; } = questIdss;
    public TagDTO[]? Tags { get; set; } = tags;
    public string ProjectTitle { get; set; } = projectTitle;
    public UserDTO? Owner { get; set; } = owner;
    public FileDTO? File { get; set; } = file;
    public int Comments { get; set; } = comments;
    public int Likes { get; set; } = likes;
}
