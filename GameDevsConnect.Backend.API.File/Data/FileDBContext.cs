namespace GameDevsConnect.Backend.API.File.Data;

public partial class FileDBContext(DbContextOptions<FileDBContext> options) : DbContext(options)
{
    public virtual DbSet<FileModel> Files { get; set; }
    public virtual DbSet<CommentModel> Comments { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<FileModel>(entity =>
        {
            entity.ToTable("file");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Name).HasColumnName("name");
            entity.Property(e => e.Size).HasColumnName("size");
            entity.Property(e => e.Created).HasColumnName("created");
            entity.Property(e => e.OwnerId).HasColumnName("ownerid");
        });
        OnModelCreatingPartial(modelBuilder);
    }
    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
