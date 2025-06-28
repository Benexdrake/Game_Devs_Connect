namespace GameDevsConnect.Backend.API.Configuration.DTOs;

public partial class ProfileDTO
{
    public string Id { get; set; } = null!;

    public string? UserId { get; set; }

    public string? DiscordUrl { get; set; }

    public string? XUrl { get; set; }

    public string? WebsiteUrl { get; set; }

    public string? Email { get; set; }

    public byte? ShowDiscord { get; set; }

    public byte? ShowX { get; set; }

    public byte? ShowWebsite { get; set; }

    public byte? ShowEmail { get; set; }
}
