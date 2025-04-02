namespace GameDevsConnect.Backend.API.Notification.Data;

public partial class NotificationDBContext(DbContextOptions<NotificationDBContext> options) : DbContext(options)
{
    public virtual DbSet<NotificationModel> Notifications { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<NotificationModel>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.ToTable("notification");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.RequestId).HasColumnName("requestId");
            entity.Property(e => e.Type).HasColumnName("type");
            entity.Property(e => e.OwnerId).HasColumnName("ownerId");
            entity.Property(e => e.UserId).HasColumnName("userId");
            entity.Property(e => e.Seen).HasColumnName("seen");
            entity.Property(e => e.Created).HasColumnName("created");
        });
        OnModelCreatingPartial(modelBuilder);
    }
    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
