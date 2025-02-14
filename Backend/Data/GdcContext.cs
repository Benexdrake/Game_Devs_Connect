using System;
using System.Collections.Generic;
using Backend.Models;
using Microsoft.EntityFrameworkCore;

namespace Backend.Data;

public partial class GdcContext : DbContext
{
    public GdcContext()
    {
    }

    public GdcContext(DbContextOptions<GdcContext> options) : base(options)
    {
    }

    public virtual DbSet<Element> Elements { get; set; }

    public virtual DbSet<Project> Projects { get; set; }

    public virtual DbSet<ProjectTeam> ProjectTeams { get; set; }

    public virtual DbSet<Request> Requests { get; set; }

    public virtual DbSet<RequestTag> RequestTags { get; set; }

    public virtual DbSet<Tag> Tags { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlite("Name=ConnectionStrings:DefaultConnection");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Element>(entity =>
        {
            entity.ToTable("element");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Config).HasColumnName("config");
            entity.Property(e => e.Content).HasColumnName("content");
            entity.Property(e => e.Elementtype).HasColumnName("elementtype");
            entity.Property(e => e.Nr).HasColumnName("nr");
            entity.Property(e => e.Projectid).HasColumnName("projectid");
            entity.HasKey(entity => entity.Id);  
        });

        modelBuilder.Entity<Project>(entity =>
        {
            entity.ToTable("project");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Description).HasColumnName("description");
            entity.Property(e => e.Headerimage).HasColumnName("headerimage");
            entity.Property(e => e.Name).HasColumnName("name");
            entity.Property(e => e.Ownerid).HasColumnName("ownerid");
            entity.HasKey(entity => entity.Id);
        });

        modelBuilder.Entity<ProjectTeam>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("project_team");

            entity.Property(e => e.Projectid).HasColumnName("projectid");
            entity.Property(e => e.Teammemberid).HasColumnName("teammemberid");
        });

        modelBuilder.Entity<Request>(entity =>
        {
            entity.ToTable("request");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Created).HasColumnName("created");
            entity.Property(e => e.Description).HasColumnName("description");
            entity.Property(e => e.Fileurl).HasColumnName("fileurl");
            entity.Property(e => e.ProjectId).HasColumnName("projectId");
            entity.Property(e => e.Title).HasColumnName("title");
            entity.Property(e => e.UserId).HasColumnName("userId");
            entity.HasKey(entity => entity.Id);
        });

        modelBuilder.Entity<RequestTag>(entity =>
        {
            entity.ToTable("request_tag");

            entity.Property(e => e.RequestId).HasColumnName("requestId");
            entity.Property(e => e.Tagname).HasColumnName("tagname");
            entity.HasKey(entity => entity.Id);
        });

        modelBuilder.Entity<Tag>(entity =>
        {
            entity.ToTable("tag");
            entity.Property(e => e.Name).HasColumnName("name");
            entity.HasKey(entity => entity.Name);
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.ToTable("user");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AccountType).HasColumnName("accountType");
            entity.Property(e => e.Avatar).HasColumnName("avatar");
            entity.Property(e => e.Banner).HasColumnName("banner");
            entity.Property(e => e.DiscordUrl).HasColumnName("discordUrl");
            entity.Property(e => e.Email).HasColumnName("email");
            entity.Property(e => e.Username).HasColumnName("username");
            entity.Property(e => e.Websiteurl).HasColumnName("websiteurl");
            entity.Property(e => e.Xurl).HasColumnName("xurl");
            entity.HasKey(entity => entity.Id);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
