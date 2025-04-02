namespace GameDevsConnect.Backend.API.Auth.Data;

public partial class AuthDBContext(DbContextOptions<AuthDBContext> options) : DbContext(options)
{
    public virtual DbSet<AuthModel> Auths { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AuthModel>(entity =>
        {
            entity.ToTable("auth");
            entity.HasKey(e => e.UserId);

            entity.Property(e => e.UserId).HasColumnName("userid");
            entity.Property(e => e.Token).HasColumnName("token");
            entity.Property(e => e.Expires).HasColumnName("expires");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
