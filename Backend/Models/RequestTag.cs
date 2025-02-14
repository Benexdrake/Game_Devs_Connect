namespace Backend.Models;

public class RequestTag
{
    //public RequestTag(string requestId, string tagName)
    //{
    //    RequestId = requestId;
    //    TagId = tagName;
    //}
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.None)]
    public string RequestId { get; set; }
    public string TagId { get; set; }


}
