using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using PagedList.Mvc;
using Portals.Models;

namespace Portals.Controllers
{
    public class SubForumController : Controller
    {
        //
        // GET: /SubForum/
        ForumDbContext forumcontext = new ForumDbContext();

        public ActionResult Index(int? id, int? page)
        {
            IPagedList<Portals.Models.ForumThread> forumthreads = forumcontext.ForumThreads.Where(f => f.ForumThreadId == id).ToPagedList(page ?? 1, 3);

            return View(forumthreads);
        }

    }
}