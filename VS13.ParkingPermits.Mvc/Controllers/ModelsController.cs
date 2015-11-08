using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace VS13.Controllers {
    public class ModelsController:Controller {
        // GET: Models
        public ActionResult Index() {
            return View();
        }
        public ActionResult Context() {
            return View();
        }
        public ActionResult Activities() {
            return View();
        }
        public ActionResult UseCases() {
            return View();
        }
        public ActionResult KeyAbstractions() {
            return View();
        }
        public ActionResult States() {
            return View();
        }
    }
}