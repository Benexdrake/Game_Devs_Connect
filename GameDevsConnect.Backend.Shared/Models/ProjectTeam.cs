namespace GameDevsConnect.Backend.Shared.Models;

public partial class ProjectTeam
{
    public string? ProjectId { get; set; }

    public string? TeamMemberId { get; set; }

    public virtual ProjectModel? Project { get; set; }

    public virtual UserModel? TeamMember { get; set; }
}
