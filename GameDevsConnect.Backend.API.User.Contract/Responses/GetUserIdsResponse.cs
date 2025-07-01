﻿using GameDevsConnect.Backend.API.Configuration.Contract.Responses;

namespace GameDevsConnect.Backend.API.User.Contract.Responses;

public class GetUserIdsResponse(string message, bool status, string[] userIds) : ApiResponse(message, status)
{
    public string[] UserIds { get; set; } = userIds;
}
