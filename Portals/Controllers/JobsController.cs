using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Portals.Controllers
{
    public class JobsController : Controller
    {
        // GET: Job
        public ActionResult Index()
        {
            return View();
        }
    }
}