using GameDevsConnect.Backend.Shared.Models;
using System;
using System.Collections.Generic;

namespace Backend.Models;

public partial class RequestLike
{
    public string? RequestId { get; set; }

    public string? OwnerId { get; set; }
}
