namespace GameDevsConnect.Backend.API.Request.Data;

public partial class RequestDBContext(DbContextOptions<RequestDBContext> options) : DbContext(options)
{
    public virtual DbSet<RequestModel> Requests { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<RequestModel>(entity =>
        {
            entity.ToTable("request");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Created).HasColumnName("created");
            entity.Property(e => e.Description).HasColumnName("description");
            entity.Property(e => e.FileId).HasColumnName("fileid");
            entity.Property(e => e.ProjectId).HasColumnName("projectId");
            entity.Property(e => e.Title).HasColumnName("title");
            entity.Property(e => e.OwnerId).HasColumnName("ownerid");
        });
        OnModelCreatingPartial(modelBuilder);
    }
    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
