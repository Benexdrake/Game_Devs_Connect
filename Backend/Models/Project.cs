namespace Backend.Models
{
    public class Project
    {
        public string Id { get; set; } = string.Empty;
        public string Header { get; set; } = string.Empty;
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string[] UserIds { get; set; } = [];
        public string[] ElementIds { get; set; } = [];
    }
}
