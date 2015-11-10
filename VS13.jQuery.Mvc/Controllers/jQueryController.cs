using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace VS13.Controllers {
    public class jQueryController:Controller {
        //Members


        //Interface
        public ActionResult Index() {
            // GET: jQuery
            return View();
        }

        public ActionResult FocusInputOnLoad() {
            //Focus an  input control on apge load
            return View();
        }

        public ActionResult ChangeFormElementState() {
            //Change state of forms elements- copy fields, enable/disable fields
            return View();
        }

        public ActionResult AutoSelectRadioButtons() {
            //Automatically select a radio button
            return View();
        }

        public ActionResult ToggleAllCheckboxes() {
            //Provide a toggle to select/deselect all checkboxes
            return View();
        }
    }
}