﻿using GameDevsConnect.Backend.Shared.Models;
using GameDevsConnect.Backend.Shared.Responses;

namespace GameDevsConnect.Backend.API.Request.Contract.Response;
public class GetByIdResponse(string message, bool status, RequestModel? request) : ApiResponse(message, status)
{
    public RequestModel? Request { get; set; } = request;
}
