namespace GameDevsConnect.Backend.API.Request.Data;

public partial class RequestDBContext(DbContextOptions<RequestDBContext> options) : DbContext(options)
{
    public virtual DbSet<RequestModel> Requests { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<RequestModel>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Requests__3213E83F7C3B1A3E");

            entity.Property(e => e.Id)
                .HasMaxLength(64)
                .HasColumnName("id");
            entity.Property(e => e.Created)
                .HasMaxLength(128)
                .HasColumnName("created");
            entity.Property(e => e.Description).HasColumnName("description");
            entity.Property(e => e.FileId)
                .HasMaxLength(64)
                .HasColumnName("file_id");
            entity.Property(e => e.OwnerId)
                .HasMaxLength(64)
                .HasColumnName("owner_id");
            entity.Property(e => e.ProjectId)
                .HasMaxLength(64)
                .HasColumnName("project_id");
            entity.Property(e => e.Title)
                .HasMaxLength(128)
                .HasColumnName("title");

            entity.HasOne(d => d.File).WithMany(p => p.Requests)
                .HasForeignKey(d => d.FileId)
                .HasConstraintName("FK__Requests__file_i__48CFD27E");

            entity.HasOne(d => d.Owner).WithMany(p => p.Requests)
                .HasForeignKey(d => d.OwnerId)
                .HasConstraintName("FK__Requests__owner___47DBAE45");

            entity.HasOne(d => d.Project).WithMany(p => p.Requests)
                .HasForeignKey(d => d.ProjectId)
                .HasConstraintName("FK__Requests__projec__46E78A0C");
        });

        OnModelCreatingPartial(modelBuilder);
    }
    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
