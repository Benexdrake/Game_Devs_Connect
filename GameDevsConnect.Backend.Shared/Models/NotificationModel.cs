using System.ComponentModel.DataAnnotations.Schema;

namespace GameDevsConnect.Backend.Shared.Models;
public partial class NotificationModel
{
    public int Id { get; set; }

    public string? RequestId { get; set; }

    public int? Type { get; set; }

    public string? OwnerId { get; set; }

    public string? UserId { get; set; }

    public bool Seen { get; set; }

    public string? Created { get; set; }

    public virtual UserModel? Owner { get; set; }


    public virtual RequestModel? Request { get; set; }


    public virtual UserModel? User { get; set; }
}
