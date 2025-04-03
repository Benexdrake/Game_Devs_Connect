namespace GameDevsConnect.Backend.API.Comment.Data;

public partial class CommentDBContext(DbContextOptions<CommentDBContext> options) : DbContext(options)
{
    public virtual DbSet<CommentModel> Comments { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<CommentModel>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Comments__3213E83F66D90817");

            entity.Property(e => e.Id)
                .HasMaxLength(64)
                .HasColumnName("id");
            entity.Property(e => e.Created)
                .HasMaxLength(128)
                .HasColumnName("created");
            entity.Property(e => e.Deleted).HasColumnName("deleted");
            entity.Property(e => e.FileId)
                .HasMaxLength(64)
                .HasColumnName("file_id");
            entity.Property(e => e.Message).HasColumnName("message");
            entity.Property(e => e.OwnerId)
                .HasMaxLength(64)
                .HasColumnName("owner_id");
            entity.Property(e => e.RequestId)
                .HasMaxLength(64)
                .HasColumnName("request_id");

            entity.HasOne(d => d.File).WithMany(p => p.Comments)
                .HasForeignKey(d => d.FileId)
                .HasConstraintName("FK__Comments__file_i__571DF1D5");

            entity.HasOne(d => d.Owner).WithMany(p => p.Comments)
                .HasForeignKey(d => d.OwnerId)
                .HasConstraintName("FK__Comments__owner___5812160E");

            entity.HasOne(d => d.Request).WithMany(p => p.Comments)
                .HasForeignKey(d => d.RequestId)
                .HasConstraintName("FK__Comments__reques__5629CD9C");
        });
        OnModelCreatingPartial(modelBuilder);
    }
    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
