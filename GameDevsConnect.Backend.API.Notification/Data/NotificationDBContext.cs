namespace GameDevsConnect.Backend.API.Notification.Data;

public partial class NotificationDBContext(DbContextOptions<NotificationDBContext> options) : DbContext(options)
{
    public virtual DbSet<NotificationModel> Notifications { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<NotificationModel>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Notifica__3213E83FFA33E195");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Created)
                .HasMaxLength(128)
                .HasColumnName("created");
            entity.Property(e => e.OwnerId)
                .HasMaxLength(64)
                .HasColumnName("owner_id");
            entity.Property(e => e.RequestId)
                .HasMaxLength(64)
                .HasColumnName("request_id");
            entity.Property(e => e.Seen).HasColumnName("seen");
            entity.Property(e => e.Type).HasColumnName("type");
            entity.Property(e => e.UserId)
                .HasMaxLength(64)
                .HasColumnName("user_id");

            entity.HasOne(d => d.Request).WithMany(p => p.Notifications)
                .HasForeignKey(d => d.RequestId)
                .HasConstraintName("FK__Notificat__reque__5165187F");
        });

        OnModelCreatingPartial(modelBuilder);
    }
    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
