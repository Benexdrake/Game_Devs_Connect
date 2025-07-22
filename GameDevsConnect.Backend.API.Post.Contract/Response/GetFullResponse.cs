namespace GameDevsConnect.Backend.API.Post.Contract.Response;

public class GetFullResponse(string message, bool status, PostDTO? post, FileDTO[] files, int questCount, TagDTO[]? tags, string projectTitle, UserDTO? owner, int comments, int likes) : ApiResponse(message, status)
{
    public PostDTO? Post { get; set; } = post;
    public FileDTO[] Files { get; set; } = files;
    public int QuestCount { get; set; } = questCount;
    public TagDTO[]? Tags { get; set; } = tags;
    public string ProjectTitle { get; set; } = projectTitle;
    public UserDTO? Owner { get; set; } = owner;
    public int Comments { get; set; } = comments;
    public int Likes { get; set; } = likes;
}
