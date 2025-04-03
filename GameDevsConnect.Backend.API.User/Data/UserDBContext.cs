namespace GameDevsConnect.Backend.API.User.Data;

public partial class UserDBContext(DbContextOptions<UserDBContext> options) : DbContext(options)
{
    public virtual DbSet<UserModel> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<UserModel>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Users__3213E83F1FAE596D");

            entity.Property(e => e.Id)
                .HasMaxLength(64)
                .HasColumnName("id");
            entity.Property(e => e.Accounttype)
                .HasMaxLength(64)
                .HasColumnName("accounttype");
            entity.Property(e => e.Avatar)
                .HasMaxLength(128)
                .HasColumnName("avatar");
            entity.Property(e => e.Username)
                .HasMaxLength(128)
                .HasColumnName("username");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
