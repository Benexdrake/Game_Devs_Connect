namespace GameDevsConnect.Backend.Shared.Models;

public partial class UserModel
{
    public string Id { get; set; } = null!;

    public string? Username { get; set; }

    public string? Avatar { get; set; }

    public string? Accounttype { get; set; }

    public virtual ICollection<CommentModel> Comments { get; set; } = [];

    public virtual ICollection<FileModel> Files { get; set; } = [];

    public virtual ICollection<ProfileModel> Profiles { get; set; } = [];

    public virtual ICollection<ProjectModel> Projects { get; set; } = [];

    public virtual ICollection<RequestModel> Requests { get; set; } = [];
}
