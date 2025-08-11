namespace GameDevsConnect.Backend.API.User.Contract.Responses;

public class GetCountResponse(string message, bool status, int count, string[] errors = null!) : ApiResponse(message, status, errors)
{
    public int Count { get; set; } = count;
}
