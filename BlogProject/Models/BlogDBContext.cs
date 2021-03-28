using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
////using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogProject.Models
{
    public class BlogDBContext : DbContext /*IdentityDbContext<IdentityUser>*/
    {
        public BlogDBContext(DbContextOptions <BlogDBContext> options) : base(options)
        {
            //Database.SetInitializer<BlogDBContext>(new CreateDatabaseIfNotExists<BlogDBContext>());
        }

        public DbSet<Post> Posts { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Category> Categories { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // configures one-to-many relationship
            //modelBuilder.Entity<Post>()
            //    .HasMany(s => s.Comments)
            //    .WithOne(g => g.Post);

            //modelBuilder.Entity<Post>()
            //    .HasOne(a => a.User)
            //    .WithOne(b => b.Post)
            //    .HasForeignKey<Post>(b => b.CreatedBy);

            //modelBuilder.Entity<Comment>()
            //    .HasOne(a => a.User)
            //    .WithOne(b => b.Comment)
            //    .HasForeignKey<Comment>(b => b.UserId);

            //base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Post>().HasOne(a => a.User)
                         .WithOne().OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Comment>().HasOne(a => a.User)
                         .WithOne().OnDelete(DeleteBehavior.Restrict);


        }

    }
}
