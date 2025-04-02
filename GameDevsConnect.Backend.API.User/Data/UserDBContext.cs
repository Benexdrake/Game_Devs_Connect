namespace GameDevsConnect.Backend.API.User.Data;

public partial class UserDBContext(DbContextOptions<UserDBContext> options) : DbContext(options)
{
    public virtual DbSet<UserModel> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<UserModel>(entity =>
        {
            entity.ToTable("user");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Username).HasColumnName("username");
            entity.Property(e => e.AccountType).HasColumnName("accountType");
            entity.Property(e => e.Avatar).HasColumnName("avatar");
        });
        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
