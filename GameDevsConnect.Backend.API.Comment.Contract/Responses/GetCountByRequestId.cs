namespace GameDevsConnect.Backend.API.Comment.Contract.Responses;

public class GetCountByRequestId(string message, bool status, int count)
{
    public string Message { get; set; } = message;
    public bool Status { get; set; } = status;
    public int Count { get; set; } = count;
}
