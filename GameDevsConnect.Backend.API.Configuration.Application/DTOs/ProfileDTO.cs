namespace GameDevsConnect.Backend.API.Configuration.Application.DTOs;

public partial class ProfileDTO(string userId)
{
    public string Id { get; init; } = Guid.NewGuid().ToString();

    public string? UserId { get; set; } = userId;

    public string? DiscordUrl { get; set; } = string.Empty;

    public string? XUrl { get; set; } = string.Empty;

    public string? WebsiteUrl { get; set; } = string.Empty;

    public string? Email { get; set; } = string.Empty;

    public bool? ShowDiscord { get; set; }

    public bool? ShowX { get; set; }

    public bool? ShowWebsite { get; set; }

    public bool? ShowEmail { get; set; }
}
