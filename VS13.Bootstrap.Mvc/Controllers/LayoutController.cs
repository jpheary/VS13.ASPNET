using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace VS13.Controllers {
    //Bootstrap Layout Components Controller
    public class LayoutController:Controller {
        //Members

        //Interface
        public ActionResult Index() {
            // GET: Layout
            return View();
        }
        public ActionResult Menus() {
            // GET: Menus
            return View();
        }
        public ActionResult Navigation() {
            // GET: Navigation
            return View();
        }
        public ActionResult Breadcrumbs() {
            // GET: Breadcrumbs
            return View();
        }
        public ActionResult Pagination() {
            // GET: Pagination
            return View();
        }
        public ActionResult Labels() {
            // GET: Labels
            return View();
        }
        public ActionResult Typographic() {
            // GET: Typographic
            return View();
        }
    }
}