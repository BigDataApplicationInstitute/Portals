using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Portals.Models
{
    public class Message
    {
        public int MessageId { get; set; }
        public string Content { get; set; }
        public DateTime Created { get; set; }
        //  public int UserId { get; set; }
        // public int ForumThreadId { get; set; }

        public virtual ForumThread ForumThread { get; set; }
        public virtual ApplicationUser User { get; set; }
    }
}