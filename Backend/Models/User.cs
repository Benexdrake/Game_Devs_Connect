namespace Backend.Models;

public partial class User
{
    public string Id { get; set; } = string.Empty;

    public string Username { get; set; } = string.Empty;

    public string Avatar { get; set; } = string.Empty;

    public string AccountType { get; set; } = string.Empty;
}
