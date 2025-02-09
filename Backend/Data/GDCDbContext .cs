namespace Backend.Data;

public class GDCDbContext(DbContextOptions<GDCDbContext> options) : DbContext(options)
{
    public DbSet<User> Users { get; set; }
    public DbSet<Project> Projects { get; set; }
    public DbSet<Request> Requests { get; set; }
}
