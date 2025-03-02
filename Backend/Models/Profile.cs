namespace Models;
public class Profile()
{
    public string UserId { get; set; } = string.Empty;
    public string Banner { get; set; } = string.Empty;
    
    public string DiscordUrl { get; set; } = string.Empty;
    public string XUrl { get; set; } = string.Empty;
    public string WebsiteUrl { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;

    public bool ShowDiscord { get; set; }
    public bool ShowX { get; set; }
    public bool ShowWebsite { get; set; }
    public bool ShowEmail { get; set; }
}