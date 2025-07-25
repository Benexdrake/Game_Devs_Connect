﻿using Microsoft.AspNetCore.Http;

namespace GameDevsConnect.Backend.API.Azure.Contract.Requests;

public class BlobRequest
{
    public IFormFile? FormFile { get; set; }
    public string FileName { get; set; } = string.Empty;
    public string ContainerName { get; set; } = string.Empty;
}
