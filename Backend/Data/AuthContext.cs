namespace Backend.Data;

public partial class AuthContext(DbContextOptions<AuthContext> options) : DbContext(options)
{
    public virtual DbSet<Auth> Auths { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    //=> optionsBuilder.UseSqlServer("Name=ConnectionStrings:MSSQLConnectionAuth");
    => optionsBuilder.UseSqlite("Name=ConnectionStrings:SQLiteConnectionAuth");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Auth>(entity =>
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
