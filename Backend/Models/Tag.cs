namespace Backend.Models;

public class Tag
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.None)]
    public string Name { get; set; } = string.Empty;
    //public ICollection<Request> Requests { get; set; } = [];
}
