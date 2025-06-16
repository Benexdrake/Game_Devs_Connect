namespace GameDevsConnect.Backend.API.Configuration.Data;

public partial class GDCDbContext(DbContextOptions<GDCDbContext> options) : DbContext(options)
{
    public virtual DbSet<UserModel> Users { get; set; }
    public virtual DbSet<TagModel> Tags { get; set; }
    public virtual DbSet<RequestModel> Requests { get; set; }
    public virtual DbSet<ProfileModel> Profiles { get; set; }
    public virtual DbSet<ProjectModel> Projects { get; set; }
    public virtual DbSet<NotificationModel> Notifications { get; set; }
    public virtual DbSet<FileModel> Files { get; set; }
    public virtual DbSet<CommentModel> Comments { get; set; }
    public virtual DbSet<RequestTag> RequestTags { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<RequestTag>(entity =>
        {
            entity.Property(e => e.RequestId).HasColumnName("request_id");
            entity.Property(e => e.TagId).HasColumnName("tag_id");
        });

        modelBuilder.Entity<CommentModel>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Comments__3213E83F66D90817");

            entity.Property(e => e.Id)
                .HasMaxLength(64)
                .HasColumnName("id");
            entity.Property(e => e.Created)
                .HasMaxLength(128)
                .HasColumnName("created");
            entity.Property(e => e.Deleted).HasColumnName("deleted");
            entity.Property(e => e.FileId)
                .HasMaxLength(64)
                .HasColumnName("file_id");
            entity.Property(e => e.Message).HasColumnName("message");
            entity.Property(e => e.OwnerId)
                .HasMaxLength(64)
                .HasColumnName("owner_id");
            entity.Property(e => e.RequestId)
                .HasMaxLength(64)
                .HasColumnName("request_id");
        });

        modelBuilder.Entity<FileModel>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Files__3213E83FF08B3AF0");

            entity.Property(e => e.Id)
                .HasMaxLength(64)
                .HasColumnName("id");
            entity.Property(e => e.Created)
                .HasMaxLength(128)
                .HasColumnName("created");
            entity.Property(e => e.Description).HasColumnName("description");
            entity.Property(e => e.OwnerId)
                .HasMaxLength(64)
                .HasColumnName("owner_id");
            entity.Property(e => e.Size).HasColumnName("size");
        });

        modelBuilder.Entity<NotificationModel>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Notifica__3213E83FFA33E195");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Created)
                .HasMaxLength(128)
                .HasColumnName("created");
            entity.Property(e => e.OwnerId)
                .HasMaxLength(64)
                .HasColumnName("owner_id");
            entity.Property(e => e.RequestId)
                .HasMaxLength(64)
                .HasColumnName("request_id");
            entity.Property(e => e.Seen).HasColumnName("seen");
            entity.Property(e => e.Type).HasColumnName("type");
            entity.Property(e => e.UserId)
                .HasMaxLength(64)
                .HasColumnName("user_id");
        });

        modelBuilder.Entity<ProfileModel>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Profiles__3213E83F90589B08");

            entity.Property(e => e.Id)
                .HasMaxLength(64)
                .HasColumnName("id");
            entity.Property(e => e.DiscordUrl)
                .HasMaxLength(64)
                .HasColumnName("discord_url");
            entity.Property(e => e.Email)
                .HasMaxLength(64)
                .HasColumnName("email");
            entity.Property(e => e.ShowDiscord).HasColumnName("show_discord");
            entity.Property(e => e.ShowEmail).HasColumnName("show_email");
            entity.Property(e => e.ShowWebsite).HasColumnName("show_website");
            entity.Property(e => e.ShowX).HasColumnName("show_x");
            entity.Property(e => e.UserId)
                .HasMaxLength(64)
                .HasColumnName("user_id");
            entity.Property(e => e.WebsiteUrl)
                .HasMaxLength(64)
                .HasColumnName("website_url");
            entity.Property(e => e.XUrl)
                .HasMaxLength(64)
                .HasColumnName("x_url");
        });

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
        });

        modelBuilder.Entity<ProjectTeam>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Project_Team");

            entity.Property(e => e.ProjectId)
                .HasMaxLength(64)
                .HasColumnName("project_id");
            entity.Property(e => e.TeamMemberId)
                .HasMaxLength(64)
                .HasColumnName("team_member_id");
        });

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
        });

        modelBuilder.Entity<RequestLike>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Request_Like");

            entity.Property(e => e.OwnerId)
                .HasMaxLength(64)
                .HasColumnName("owner_id");
            entity.Property(e => e.RequestId)
                .HasMaxLength(64)
                .HasColumnName("request_id");
        });

        modelBuilder.Entity<RequestTag>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Request_Tag");

            entity.Property(e => e.RequestId)
                .HasMaxLength(64)
                .HasColumnName("request_id");
            entity.Property(e => e.TagId).HasColumnName("tag_id");
        });

        modelBuilder.Entity<TagModel>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Tags__3213E83FFFD2E1F7");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Tag)
                .HasMaxLength(128)
                .HasColumnName("tag");
        });

        modelBuilder.Entity<UserModel>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Users__3213E83F1FAE596D");

            entity.Property(e => e.Id)
                .HasMaxLength(64)
                .HasColumnName("id");
            entity.Property(e => e.Accounttype)
                .HasMaxLength(64)
                .HasColumnName("accounttype");
            entity.Property(e => e.Avatar)
                .HasMaxLength(128)
                .HasColumnName("avatar");
            entity.Property(e => e.Username)
                .HasMaxLength(128)
                .HasColumnName("username");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
