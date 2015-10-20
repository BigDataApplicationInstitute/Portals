using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Portals.Models
{
    public class Blog
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public Nullable<System.DateTime> PostTime { get; set; }
        public string PostUserId { get; set; }
        public Nullable<int> IsHome { get; set; }
        public Nullable<int> Status { get; set; }
    }
}