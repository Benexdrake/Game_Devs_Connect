namespace GameDevsConnect.Backend.API.Tag.Data;

public partial class TagDBContext(DbContextOptions<TagDBContext> options) : DbContext(options)
{
    public virtual DbSet<TagModel> Tags { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TagModel>(entity =>
        {
            entity.HasKey(e => e.Id);

            entity.ToTable("tag");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Name).HasColumnName("name");
        });
        OnModelCreatingPartial(modelBuilder);
    }
    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
