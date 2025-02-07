
namespace Backend.Data;

public class UserDbContext : DbContext
{
    public DbSet<User> Users { get; set; }

    public UserDbContext(DbContextOptions<UserDbContext> options) : base(options) {}
}
