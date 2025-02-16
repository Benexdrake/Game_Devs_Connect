namespace Backend.Models;

public partial class User
{
    public string Id { get; set; } = string.Empty;

    public string Username { get; set; } = string.Empty;

    public string Avatar { get; set; } = string.Empty;

    public string AccountType { get; set; } = string.Empty;

    public string Banner { get; set; } = string.Empty;

    public string DiscordUrl { get; set; } = string.Empty;

    public string Xurl { get; set; } = string.Empty;

    public string Websiteurl { get; set; } = string.Empty;

    public string Email { get; set; } = string.Empty;
}
