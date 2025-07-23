using Microsoft.AspNetCore.Http;

namespace GameDevsConnect.Backend.API.Azure.Contract.Requests;

public class UploadFormRequest
{
    public IFormFile? FormFile { get; set; }

    public string Request { get; set; } = string.Empty;
}
