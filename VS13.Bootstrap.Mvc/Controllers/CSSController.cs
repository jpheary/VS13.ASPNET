using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace VS13.Controllers {
    //Botstrap CSS Controller
    public class CSSController:Controller {
        //Members

        //Interface
        public ActionResult Index() {
            // GET: Index
            return View();
        }
        public ActionResult Typography() {
            // GET: Typography
            return View();
        }
        public ActionResult Code() {
            // GET: Code
            return View();
        }
        public ActionResult Tables() {
            // GET: Tables
            return View();
        }
        public ActionResult Forms() {
            // GET: Forms
            return View();
        }
        public ActionResult Buttons() {
            // GET: Buttons
            return View();
        }
        public ActionResult Images() {
            // GET: Images
            return View();
        }
    }
}