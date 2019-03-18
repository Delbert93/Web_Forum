using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Web_HW03.Models;

namespace Web_HW03.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<PostTag>()
                .HasKey(boatyMcBoatface => new { boatyMcBoatface.PostId, boatyMcBoatface.TagId });

            builder.Entity<PostTag>()
                .HasOne(pt => pt.Post)
                    .WithMany(p => p.PostTags)
                .HasForeignKey(pt => pt.PostId);
            
            builder.Entity<Comment>()
                .HasOne(pt => pt.Comments)
                    .WithMany(t => t.Comments)
                .HasForeignKey(pt => pt.TagId);

            builder.Entity<Comment>()
                .HasOne(pt => pt.Post)
                    .WithMany(t => t.Comments)
                .HasForeignKey(pt => pt.Id);
        }
        public DbSet<BlogPost> BlogPosts { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<PostTag> PostTag { get; set; }
        public DbSet<Comment> Comments { get; set; }
    }
}
