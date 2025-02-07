namespace Backend.Models
{
    public class User
    {
        public string Id { get; set; } = string.Empty;
        public string Username { get; set; } = string.Empty;
        public string Avatar { get; set; } = string.Empty;
        public string AccountType { get; set; } = string.Empty;
        public string Banner { get; set; } = string.Empty;
        public Profil Profil { get; set; } = new();
        public Project[] Projects { get; set; } = [];
        public Request[] Requests { get; set; } = [];
    }
}
