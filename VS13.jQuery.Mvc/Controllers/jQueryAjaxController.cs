using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace VS13.Controllers {
    public class jQueryAjaxController:Controller {
        //Members


        //Interface
        public ActionResult Index() {
            // GET: jQueryAjax
            return View();
        }

        public ActionResult StringReturn() {
            // GET: jQueryAjax
            return View();
        }

        [HttpGet]
        public string StringCheck(string number) {
            //Return a string- maybe validate something like odd/even and return an error message
            if (int.Parse(number) % 2 == 1)
                return "Odd numbers are not permited.";
            else
                return "";
        }
    }
}