namespace GameDevsConnect.Backend.API.Configuration.Application.Data;

public partial class GDCDbContext(DbContextOptions<GDCDbContext> options) : DbContext(options)
{
    public virtual DbSet<UserDTO> Users { get; set; }
    public virtual DbSet<UserFollowDTO> UserFollows { get; set; }
    public virtual DbSet<TagDTO> Tags { get; set; }
    public virtual DbSet<QuestDTO> Quests { get; set; }
    public virtual DbSet<PostDTO> Posts { get; set; }
    public virtual DbSet<ProfileDTO> Profiles { get; set; }
    public virtual DbSet<ProjectDTO> Projects { get; set; }
    public virtual DbSet<ProjectFollowDTO> ProjectFollwers { get; set; }
    public virtual DbSet<NotificationDTO> Notifications { get; set; }
    public virtual DbSet<FileDTO> Files { get; set; }
    public virtual DbSet<PostTagDTO> PostTags { get; set; }
    public virtual DbSet<PostFileDTO> PostFiles { get; set; }
    public virtual DbSet<FavoriteQuestDTO> FavoriteQuests { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<FavoriteQuestDTO>(entity =>
        {
            entity.HasKey(e => new { e.QuestId, e.UserId }).HasName("Favorite_Quest");

            entity.Property(e => e.QuestId).HasColumnName("quest_id");
            entity.Property(e => e.UserId).HasColumnName("user_id");
        });

        modelBuilder.Entity<FileDTO>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Files");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Url).HasColumnName("url");
            entity.Property(e => e.Created).HasColumnName("created");
            entity.Property(e => e.Type).HasColumnName("type");
            entity.Property(e => e.OwnerId).HasColumnName("owner_id");
            entity.Property(e => e.Size).HasColumnName("size");
        });

        modelBuilder.Entity<NotificationDTO>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Notification");

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

        modelBuilder.Entity<ProfileDTO>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Profiles");

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

        modelBuilder.Entity<ProjectDTO>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Projects");

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

        modelBuilder.Entity<ProjectFollowDTO>(entity =>
        {
            entity.HasNoKey().ToTable("Project_Follow");

            entity.Property(e => e.UserId).HasColumnName("user_id");
            entity.Property(e => e.ProjectId).HasColumnName("project_id");
        });

        modelBuilder.Entity<ProjectTeamDTO>(entity =>
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

        modelBuilder.Entity<PostDTO>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Posts");

            entity.Property(e => e.Id)
                .HasMaxLength(64)
                .HasColumnName("id");
            entity.Property(e => e.Created)
                .HasMaxLength(128)
                .HasColumnName("created");
            entity.Property(e => e.Message).HasColumnName("message");
            entity.Property(e => e.OwnerId)
                .HasMaxLength(64)
                .HasColumnName("owner_id");
            entity.Property(e => e.ProjectId)
                .HasMaxLength(64)
                .HasColumnName("project_id");
            entity.Property(e => e.ParentId)
                .HasMaxLength(64)
                .HasColumnName("parent_id");
            entity.Property(e => e.HasQuest).HasColumnName("has_quest");
            entity.Property(e => e.IsDeleted).HasColumnName("is_deleted");
            entity.Property(e => e.Completed).HasColumnName("completed");
        });

        modelBuilder.Entity<PostFileDTO>(entity =>
        {
            entity.HasKey(e => new { e.PostId, e.FileId }).HasName("Post_File");

            entity.Property(e => e.PostId).HasColumnName("post_id");
            entity.Property(e => e.FileId).HasColumnName("file_id");
        });

        modelBuilder.Entity<PostLikeDTO>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Post_Like");

            entity.Property(e => e.OwnerId)
                .HasMaxLength(64)
                .HasColumnName("owner_id");
            entity.Property(e => e.RequestId)
                .HasMaxLength(64)
                .HasColumnName("request_id");
        });

        modelBuilder.Entity<PostTagDTO>(entity =>
        {
            entity.HasKey(e => new { e.PostId, e.Tag }).HasName("Post_Tag");

            entity.Property(e => e.PostId)
                .HasMaxLength(64)
                .HasColumnName("post_id");
            entity.Property(e => e.Tag).HasColumnName("tag");
        });

        modelBuilder.Entity<QuestDTO>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Quest");
            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.PostId).HasColumnName("post_id");
            entity.Property(e => e.OwnerId).HasColumnName("owner_id");
            entity.Property(e => e.Difficulty).HasColumnName("difficulty");
            entity.Property(e => e.Title).HasColumnName("title");
            entity.Property(e => e.Description).HasColumnName("description");
        });

        modelBuilder.Entity<TagDTO>(entity =>
        {
            entity.HasKey(e => e.Tag).HasName("PK__Tags");

            entity.Property(e => e.Type).HasColumnName("type");
            entity.Property(e => e.Tag).HasColumnName("tag");
        });

        modelBuilder.Entity<UserDTO>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Users");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.LoginId).HasColumnName("login_id");
            entity.Property(e => e.Accounttype).HasColumnName("accounttype");
            entity.Property(e => e.Avatar).HasColumnName("avatar");
            entity.Property(e => e.Username).HasColumnName("username");
        });

        modelBuilder.Entity<UserFollowDTO>(entity =>
        {
            entity.HasNoKey().ToTable("User_Follow");

            entity.Property(e => e.UserId).HasColumnName("user_id");
            entity.Property(e => e.FollowId).HasColumnName("follow_id");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
