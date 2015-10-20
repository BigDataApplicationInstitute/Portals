using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;


namespace Portals.Models
{
    [Table("Forum")]
    public class Forum
    {
        public int ForumId { get; set; }
        public string ForumTitle { get; set; }

        public virtual List<SubForum> SubForum { get; set; }
    }

    public class SubForum
    {
        public int SubForumId { get; set; }
        public string Title { get; set; }
        public bool Visible { get; set; }

        public virtual List<ForumThread> ForumThreadId { get; set; }
        public virtual Forum Forum { get; set; }

    }

    public class ForumThread
    {
        public int ForumThreadId { get; set; }
        public string Title { get; set; }
        public List<Message> MessageId { get; set; }
        public DateTime CreatedOn { get; set; }
        //public int UserId { get; set; }
        public int SubForumId { get; set; }

        public virtual SubForum SubForum { get; set; }
        public virtual ApplicationUser User { get; set; }
        public virtual Forum Forum { get; set; }
    }

}