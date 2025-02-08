namespace Backend.Models
{
    public class User
    {
        public string Id { get; set; } = string.Empty;
        public string Username { get; set; } = string.Empty;
        public string Avatar { get; set; } = string.Empty;
        public string AccountType { get; set; } = string.Empty;
        public string Banner { get; set; } = string.Empty;
        public string DiscordUrl { get; set; } = string.Empty;
        public string XUrl { get; set; } = string.Empty;
        public string WebsiteUrl { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string[] ProjectIds { get; set; } = [];
        public string[] RequestIds { get; set; } = [];
    }
}
