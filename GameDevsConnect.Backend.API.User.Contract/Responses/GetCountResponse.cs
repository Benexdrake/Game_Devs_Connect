﻿namespace GameDevsConnect.Backend.API.User.Contract.Responses;

public class GetCountResponse(string message, bool status, int count, string[] errors = default!)
{
    public ApiResponse Response { get; set; } = new ApiResponse(message, status, errors);
    public int Count { get; set; } = count;
}
