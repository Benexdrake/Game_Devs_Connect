﻿namespace GameDevsConnect.Backend.API.Configuration.DTOs;

public partial class UserDTO
{
    public string Id { get; set; } = null!;

    public string? Username { get; set; }

    public string? Avatar { get; set; }

    public string? Accounttype { get; set; }
}
