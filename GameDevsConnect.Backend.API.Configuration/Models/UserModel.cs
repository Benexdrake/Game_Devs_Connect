namespace GameDevsConnect.Backend.API.Configuration.Models;

public partial class UserModel
{
    public string Id { get; set; } = null!;

    public string? Username { get; set; }

    public string? Avatar { get; set; }

    public string? Accounttype { get; set; }
}
