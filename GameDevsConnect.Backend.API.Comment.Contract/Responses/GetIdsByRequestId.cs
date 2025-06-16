namespace GameDevsConnect.Backend.API.Comment.Contract.Responses;

public class GetIdsByRequestId(string message, bool status, string[] ids) : ApiResponse(message, status)
{
    public string[] Ids { get; set; } = ids;
}
