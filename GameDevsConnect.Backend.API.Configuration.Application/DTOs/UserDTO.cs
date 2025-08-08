namespace GameDevsConnect.Backend.API.Configuration.Application.DTOs;

public partial class UserDTO
{
    public string Id { get; set; } = null!;
    public string LoginId { get; set; } = null!;

    public string? Username { get; set; }

    public string? Avatar { get; set; }

    public string? Accounttype { get; set; }

    public UserDTO() {}

    public UserDTO(string id, string loginId, string? username, string? avatar, string? accounttype)
    {
        Id = id;
        LoginId = loginId;
        Username = username;
        Avatar = avatar;
        Accounttype = accounttype;
    }
}
