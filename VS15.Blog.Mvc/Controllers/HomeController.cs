using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using VS15.Blog.Models;

namespace VS15.Blog.Controllers {
    public class HomeController:Controller {
        //Members
        private BlogGateway gateway = new BlogGateway();

        //Interface
        public ActionResult Index() {
            var blogs = gateway.Blogs;
            return View(blogs.ToList());
        }
        public ActionResult Blog(int? id) {
            // GET: Blogs/Blog/5
            if (id == null) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            Models.Blog blog = gateway.Blogs.Find(id);
            if (blog == null) return HttpNotFound();
            return PartialView(blog);
        }


        public ActionResult About() {
            return View();
        }
    }
}