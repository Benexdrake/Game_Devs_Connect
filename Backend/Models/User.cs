using System;
using System.Collections.Generic;

namespace Backend.Models;

public partial class User
{
    public string Id { get; set; } = null!;

    public string? Username { get; set; }

    public string? Avatar { get; set; }

    public string? AccountType { get; set; }

    public string? Banner { get; set; }

    public string? DiscordUrl { get; set; }

    public string? Xurl { get; set; }

    public string? Websiteurl { get; set; }

    public string? Email { get; set; }
}
