namespace GameDevsConnect.Backend.API.Project.Data;

public partial class ProjectDBContext(DbContextOptions<ProjectDBContext> options) : DbContext(options)
{
    public virtual DbSet<ProjectModel> Projects { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ProjectModel>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Projects__3213E83F52B40C40");

            entity.Property(e => e.Id)
                .HasMaxLength(64)
                .HasColumnName("id");
            entity.Property(e => e.Description).HasColumnName("description");
            entity.Property(e => e.OwnerId)
                .HasMaxLength(64)
                .HasColumnName("owner_id");
            entity.Property(e => e.Title)
                .HasMaxLength(128)
                .HasColumnName("title");

            entity.HasOne(d => d.Owner).WithMany(p => p.Projects)
                .HasForeignKey(d => d.OwnerId)
                .HasConstraintName("FK__Projects__owner___3C69FB99");
        });

        OnModelCreatingPartial(modelBuilder);
    }
    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
