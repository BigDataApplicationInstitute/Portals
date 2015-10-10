using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

namespace Portals.Models
{
    public class ForumsContext : DbContext
    {
        public ForumsContext()
            : base("ForumsContext")
        {

        }

        public DbSet<Forum> Forums { get; set; }
        public DbSet<Thread> Threads { get; set; }
        public DbSet<Post> Posts { get; set; }
    }
}