using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Portals.Models
{
    public class Thread
    {
        public int ThreadId { get; set; }
        public string Title { get; set; }
        public DateTime DateCreated { get; set; }

        public int ForumId { get; set; }
        public virtual Forum Forum { get; set; }

        public List<Post> Posts { get; set; }
    }
}