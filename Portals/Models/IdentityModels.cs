using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;

namespace Portals.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public string Email { get; set; }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection")
        {
        }
    }

    public class ForumDbContext : IdentityDbContext<ApplicationUser>
    {
        public ForumDbContext()
            : base("ForumEntities")
        {
        }

        public DbSet<Message> Messages { get; set; }
        public DbSet<SubForum> SubForums { get; set; }
        public DbSet<ForumThread> ForumThreads { get; set; }
        public DbSet<Forum> Forums { get; set; }

        public static ForumDbContext Create()
        {
            return new ForumDbContext();
        }
    }

    public class BlogDbContext : IdentityDbContext<ApplicationUser>
    {
        public BlogDbContext()
            : base("BlogEntities")
        {
        }

        public virtual DbSet<Blog> Blog { get; set; }
        public virtual DbSet<Course> Courses { get; set; }

        public static BlogDbContext Create()
        {
            return new BlogDbContext();
        }
    }
}