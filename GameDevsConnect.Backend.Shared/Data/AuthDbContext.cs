using GameDevsConnect.Backend.Shared.Models;
using Microsoft.EntityFrameworkCore;

namespace GameDevsConnect.Backend.Shared.Data;
public partial class AuthDbContext(DbContextOptions<AuthDbContext> options) : DbContext(options)
{
    public virtual DbSet<AuthModel> Auth { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AuthModel>(entity =>
        {
            entity.HasKey(e => e.UserId);

            entity.Property(e => e.UserId).HasColumnName("userid");
            entity.Property(e => e.Token).HasColumnName("token");
            entity.Property(e => e.Expires).HasColumnName("expires");
        });
        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
