using Models;

namespace Backend.Data;
public partial class GdcContext(DbContextOptions<GdcContext> options) : DbContext(options)
{
    public virtual DbSet<Comment> Comments { get; set; }
    public virtual DbSet<Project> Projects { get; set; }
    public virtual DbSet<ProjectTeam> ProjectTeams { get; set; }
    public virtual DbSet<Request> Requests { get; set; }
    public virtual DbSet<RequestTag> RequestTags { get; set; }
    public virtual DbSet<RequestLikes> RequestLikes { get; set; }
    public virtual DbSet<Tag> Tags { get; set; }
    public virtual DbSet<User> Users { get; set; }
    public virtual DbSet<Models.File> Files { get; set; }
    public virtual DbSet<Notification> Notifications { get; set; }


    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //=> optionsBuilder.UseSqlServer("Server=.;Database=GDC;Trusted_Connection=True;TrustServerCertificate=True");
        => optionsBuilder.UseSqlite("Name=ConnectionStrings:DefaultConnection");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Comment>(entity =>
        {
            entity.ToTable("comment");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.FileId).HasColumnName("fileid");
            entity.Property(e => e.Message).HasColumnName("message");
            entity.Property(e => e.ParentId).HasColumnName("parentid");
            entity.Property(e => e.Created).HasColumnName("created");
            entity.Property(e => e.OwnerId).HasColumnName("ownerid");
        });

        modelBuilder.Entity<Models.File>(entity =>
        {
            entity.ToTable("file");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Name).HasColumnName("name");
            entity.Property(e => e.Size).HasColumnName("size");
            entity.Property(e => e.Created).HasColumnName("created");
            entity.Property(e => e.OwnerId).HasColumnName("ownerid");
        });

        modelBuilder.Entity<Project>(entity =>
        {
            entity.ToTable("project");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Name).HasColumnName("name");
            entity.Property(e => e.Ownerid).HasColumnName("ownerid");
        });

        modelBuilder.Entity<ProjectTeam>(entity =>
        {
            entity.ToTable("project_team");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Projectid).HasColumnName("projectid");
            entity.Property(e => e.Teammemberid).HasColumnName("teammemberid");
        });

        modelBuilder.Entity<Request>(entity =>
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

        modelBuilder.Entity<RequestTag>(entity =>
        {
            entity.ToTable("request_tag");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.RequestId).HasColumnName("requestId");
            entity.Property(e => e.TagId).HasColumnName("tagid");
        });

        modelBuilder.Entity<RequestLikes>(entity =>
        {
            entity.ToTable("request_like");
            entity.HasKey(e => e.Id);

            entity.Property(e => e.Id).HasColumnName("Id");
            entity.Property(e => e.RequestId).HasColumnName("requestId");
            entity.Property(e => e.UserId).HasColumnName("userId");
        });

        modelBuilder.Entity<Tag>(entity =>
        {
            entity.HasKey(e => e.Name);

            entity.ToTable("tag");

            entity.Property(e => e.Name).HasColumnName("name");
        });

        modelBuilder.Entity<Notification>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.ToTable("notification");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.RequestId).HasColumnName("requestId");
            entity.Property(e => e.Type).HasColumnName("type");
            entity.Property(e => e.OwnerId).HasColumnName("ownerId");
            entity.Property(e => e.UserId).HasColumnName("userId");
            entity.Property(e => e.Seen).HasColumnName("seen");
            entity.Property(e => e.Created).HasColumnName("created");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.ToTable("user");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Username).HasColumnName("username");
            entity.Property(e => e.AccountType).HasColumnName("accountType");
            entity.Property(e => e.Avatar).HasColumnName("avatar");

        });

        modelBuilder.Entity<Profile>(entity =>
        {
            entity.ToTable("profile");

            entity.Property(e => e.Banner).HasColumnName("banner");
            entity.Property(e => e.DiscordUrl).HasColumnName("discordUrl");
            entity.Property(e => e.Email).HasColumnName("email");
            entity.Property(e => e.WebsiteUrl).HasColumnName("websiteurl");
            entity.Property(e => e.XUrl).HasColumnName("xurl");
            entity.Property(e => e.ShowDiscord).HasColumnName("showdiscord");
            entity.Property(e => e.ShowX).HasColumnName("showx");
            entity.Property(e => e.ShowEmail).HasColumnName("showemail");
            entity.Property(e => e.ShowWebsite).HasColumnName("showwebsite");

        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
