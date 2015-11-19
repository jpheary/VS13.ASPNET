using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace VS13.Controllers {
    //Bootstrap JavaScript Plugins Controller
    public class PluginsController:Controller {
        //Members

        //Interface
        public ActionResult Index() {
            // GET: Plugins
            return View();
        }
        public ActionResult Modal() {
            // GET: 
            return View();
        }
        public ActionResult Scrollspy() {
            // GET: 
            return View();
        }
        public ActionResult Collapse() {
            // GET: 
            return View();
        }
        public ActionResult Carousel() {
            // GET: 
            return View();
        }
    }
}