using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Portals.Models
{
    public class Thread
    {
        public string Title { get; set; }
        public int SubForumId { get; set; }
        public Message ForumMessage { get; set; }
        public IPagedList<Message> Message { get; set; }
    }
}