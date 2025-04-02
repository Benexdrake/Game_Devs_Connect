namespace GameDevsConnect.Backend.API.Comment.Data;

public partial class CommentDBContext(DbContextOptions<CommentDBContext> options) : DbContext(options)
{
    public virtual DbSet<CommentModel> Comments { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<CommentModel>(entity =>
        {
            entity.ToTable("comment");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.FileId).HasColumnName("fileid");
            entity.Property(e => e.Message).HasColumnName("message");
            entity.Property(e => e.ParentId).HasColumnName("parentid");
            entity.Property(e => e.Created).HasColumnName("created");
            entity.Property(e => e.OwnerId).HasColumnName("ownerid");
        });
        OnModelCreatingPartial(modelBuilder);
    }
    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
