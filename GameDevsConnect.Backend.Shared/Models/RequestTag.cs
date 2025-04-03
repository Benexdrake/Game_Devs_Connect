namespace GameDevsConnect.Backend.Shared.Models;

public partial class RequestTag
{
    public string? RequestId { get; set; }

    public int? TagId { get; set; }

    public virtual RequestModel? Request { get; set; }

    public virtual TagModel? Tag { get; set; }
}
