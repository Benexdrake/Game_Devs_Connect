namespace GameDevsConnect.Backend.API.Tag.Data;

public partial class TagDBContext(DbContextOptions<TagDBContext> options) : DbContext(options)
{
    public virtual DbSet<TagModel> Tags { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TagModel>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Tags__3213E83FFFD2E1F7");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Tag)
                .HasMaxLength(128)
                .HasColumnName("tag");
        });

        OnModelCreatingPartial(modelBuilder);
    }
    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
