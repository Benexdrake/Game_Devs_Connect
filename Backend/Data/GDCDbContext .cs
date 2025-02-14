namespace Backend.Data;

public class GDCDbContext(DbContextOptions<GDCDbContext> options) : DbContext(options)
{
    public DbSet<User> Users { get; set; }
    public DbSet<Project> Projects { get; set; }
    public DbSet<Request> Requests { get; set; }
    public DbSet<Tag> Tags { get; set; }
    public DbSet<RequestTag> RequestTag { get; set; }

    //protected override void OnModelCreating(ModelBuilder mb)
    //{
    //    mb.Entity<Request>()
    //        .HasMany(e => e.Tags)
    //        .WithMany(e => e.Requests)
    //        .UsingEntity(
    //            "RequestTag",
    //            l => l.HasOne(typeof(Tag)).WithMany().HasForeignKey("TagId").HasPrincipalKey(nameof(Tag.Name)),
    //            r => r.HasOne(typeof(Request)).WithMany().HasForeignKey("RequestId").HasPrincipalKey(nameof(Request.Id)),
    //            j => j.HasKey("RequestId", "TagId"));

    //}
}
