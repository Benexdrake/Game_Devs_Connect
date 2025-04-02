namespace GameDevsConnect.Backend.API.Project.Data;

public partial class ProjectDBContext(DbContextOptions<ProjectDBContext> options) : DbContext(options)
{
    public virtual DbSet<ProjectModel> Projects { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ProjectModel>(entity =>
        {
            entity.ToTable("project");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Name).HasColumnName("name");
            entity.Property(e => e.Ownerid).HasColumnName("ownerid");
        });
        OnModelCreatingPartial(modelBuilder);
    }
    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
