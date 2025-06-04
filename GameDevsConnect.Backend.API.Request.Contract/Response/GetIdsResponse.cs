namespace GameDevsConnect.Backend.API.Request.Contract.Response;

public class GetIdsResponse(string message, bool status, string[]? ids)
{
    public string Message { get; set; } = message;
    public bool Status { get; set; } = status;
    public string[]? Ids { get; set; } = ids;
}