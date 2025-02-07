namespace Backend.Data
{
    public class ProjectDbContext : DbContext
    {
        public DbSet<Project> Projects { get; set; }

        public ProjectDbContext(DbContextOptions<ProjectDbContext> options) : base(options) {}
    }
}
