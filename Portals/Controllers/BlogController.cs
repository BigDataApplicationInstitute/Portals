using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Portals.Models;
using Microsoft.AspNet.Identity;

namespace Portals.Controllers
{
    public class BlogController : Controller
    {
        BlogDbContext blogDb = new BlogDbContext();
        // GET: /Blog/
        public ActionResult Index()
        {
            return View(blogDb.Blog.ToList());
        }
        public ActionResult Detail(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Blog blogItem = blogDb.Blog.Where(x => x.Id == id && x.Status == 1).FirstOrDefault();
            if (blogItem == null)
            {
                return HttpNotFound();
            }
            ViewBag.username = User.Identity.Name;
            return View(blogItem);
        }
        [Authorize(Roles = "admin")]
        public ActionResult AdminIndex()
        {
            return View(blogDb.Blog.ToList());
        }

        // GET: /Blog/Create
        [Authorize(Roles = "admin")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Blog/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost,ValidateInput(false)]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Blog blog)
        {
            if (ModelState.IsValid)
            {
                blog.PostTime = DateTime.Now;
                blog.PostUserId = User.Identity.GetUserId();
                blog.IsHome = 0;
                blog.Status = 1;
                blogDb.Blog.Add(blog);
                blogDb.SaveChanges();
                return RedirectToAction("AdminIndex");
            }

            return View(blog);
        }

        // GET: /Blog/Edit/5
        [Authorize(Roles = "admin")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Blog blog = blogDb.Blog.Find(id);
            if (blog == null)
            {
                return HttpNotFound();
            }
            return View(blog);
        }

        // POST: /Blog/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost, ValidateInput(false)]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Blog blog)
        {
            if (ModelState.IsValid)
            {
                blogDb.Entry(blog).State = EntityState.Modified;
                blogDb.SaveChanges();
                return RedirectToAction("AdminIndex");
            }
            return View(blog);
        }

        // GET: /Blog/Delete/5
        [Authorize(Roles = "admin")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Blog blog = blogDb.Blog.Find(id);
            if (blog == null)
            {
                return HttpNotFound();
            }
            return View(blog);
        }

        // POST: /Blog/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Blog blog = blogDb.Blog.Find(id);
            blogDb.Blog.Remove(blog);
            blogDb.SaveChanges();
            return RedirectToAction("AdminIndex");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                blogDb.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
