namespace GameDevsConnect.Backend.API.Azure.Contract.Requests;

public class UploadRequest
{
    public string FileName { get; set; }
    public string ContainerName { get; set; }
}
