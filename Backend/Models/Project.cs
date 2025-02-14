namespace Backend.Models
{
    public class Project
    {
        public string Id { get; set; } = string.Empty;
        public string HeaderImage { get; set; } = string.Empty;
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string OwnerId { get; set; } = string.Empty;
    }
}
