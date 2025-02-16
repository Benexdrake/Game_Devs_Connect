namespace Backend.Models;

public partial class RequestTag
{
    public int Id { get; set; }
    public int RequestId { get; set; }

    public int TagId { get; set; }
}
