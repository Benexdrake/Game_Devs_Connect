namespace GameDevsConnect.Backend.API.Configuration.Application.DTOs;

public partial class ProfileDTO
{
    public string Id { get; init; } = string.Empty;

    public string UserId { get; set; } = string.Empty;

    public string DiscordUrl { get; set; } = string.Empty;

    public string XUrl { get; set; } = string.Empty;

    public string WebsiteUrl { get; set; } = string.Empty;

    public string Email { get; set; } = string.Empty;

    public bool ShowDiscord { get; set; }

    public bool ShowX { get; set; }

    public bool ShowWebsite { get; set; }

    public bool ShowEmail { get; set; }

    public ProfileDTO(string id, string userId, string discordUrl, string xUrl, string websiteUrl, string email, bool showDiscord, bool showX, bool showWebsite, bool showEmail)
    {
        Id = id;
        UserId = userId;
        DiscordUrl = discordUrl;
        XUrl = xUrl;
        WebsiteUrl = websiteUrl;
        Email = email;
        ShowDiscord = showDiscord;
        ShowX = showX;
        ShowWebsite = showWebsite;
        ShowEmail = showEmail;
    }

    public ProfileDTO() { }

    public ProfileDTO(string id, string userId)
    {
        Id = id;
        UserId = userId;
    }
}
