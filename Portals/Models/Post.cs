using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Portals.Models
{
    public class Post
    {
        public int PostId { get; set; }
        public string Content { get; set; }

        public int ThreadId { get; set; }
        public virtual Thread Thread { get; set; }
    }
}