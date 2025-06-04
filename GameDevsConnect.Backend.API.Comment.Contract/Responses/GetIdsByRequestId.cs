namespace GameDevsConnect.Backend.API.Comment.Contract.Responses;

public class GetIdsByRequestId(string message, bool status, string[] ids)
{
    public string Message { get; set; } = message;
    public bool Status { get; set; } = status;
    public string[] Ids { get; set; } = ids;
}
