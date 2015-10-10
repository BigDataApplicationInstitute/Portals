using Portals.DAL;
using Portals.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Portals.Controllers
{
    public class ForumController : Controller
    {
        private IForumRepository forumRepository;

        public ForumController()
        {
            this.forumRepository = new ForumRepository(new ForumsContext());
        }

        public ForumController(IForumRepository forumRepository)
        {
            this.forumRepository = forumRepository;
        }

        public ViewResult Index()
        {
            var forums = forumRepository.GetForums().OrderBy(f => f.Sequence);
            return View(forums);
        }

        [HttpPost]
        public ActionResult Create(Models.Forum forum)
        {
            forumRepository.CreateForum(forum);
            return View("Create");
        }

        [HttpPost]
        public RedirectToRouteResult Delete(int forumId)
        {
            forumRepository.DeleteForum(forumId);
            return RedirectToAction("Index");
        }
    }
}