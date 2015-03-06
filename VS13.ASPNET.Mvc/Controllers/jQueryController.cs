using System.Web.Mvc;
using VS13.Models;

namespace VS13.Controllers {
    public class jQueryController:Controller {
        // GET: jQuery
        public ActionResult Index() { return View(new Shipment()); }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index([Bind(Include = "ShipDate")] Shipment shipment) {
            // To protect from overposting attacks, please enable the specific properties you want to bind to, for more details see http://go.microsoft.com/fwlink/?LinkId=317598.
           if (ModelState.IsValid) {
                //
                ViewData["message"] = "You submitted a ship date of " + shipment.ShipDate.ToString("MM/dd/yyyy");
                return View(shipment);
           }
            return View(shipment);
        }
    }
}