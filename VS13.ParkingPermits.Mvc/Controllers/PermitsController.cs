using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using VS13.Models;

namespace VS13.Controllers {
    public class PermitsController:Controller {
        private PermitsGateway db = new PermitsGateway();

        // GET: Permits
        public ActionResult Index() {
            var parkingPermits = db.ParkingPermits.Include(p => p.Vehicle);
            return View(parkingPermits.ToList());
        }

        // GET: Permits/Details/5
        public ActionResult Details(int? id) {
            if (id == null) {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ParkingPermit parkingPermit = db.ParkingPermits.Find(id);
            if (parkingPermit == null) {
                return HttpNotFound();
            }
            return PartialView(parkingPermit);
        }

        // GET: Permits/Register
        public ActionResult Register() {
            ViewBag.VehicleID = new SelectList(db.Vehicles,"VehicleID","IssueState");
            return View();
        }

        // POST: Permits/Register
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register([Bind(Include = "ParkingPermitID,VehicleID,Number,Activated,ActivatedBy,Inactivated,InactivatedBy,InactivatedReason")] ParkingPermit parkingPermit) {
            if (ModelState.IsValid) {
                db.ParkingPermits.Add(parkingPermit);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.VehicleID = new SelectList(db.Vehicles,"VehicleID","IssueState",parkingPermit.VehicleID);
            return View(parkingPermit);
        }

        // GET: Permits/Edit/5
        public ActionResult Edit(int? id) {
            if (id == null) {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ParkingPermit parkingPermit = db.ParkingPermits.Find(id);
            if (parkingPermit == null) {
                return HttpNotFound();
            }
            ViewBag.VehicleID = new SelectList(db.Vehicles,"VehicleID","IssueState",parkingPermit.VehicleID);
            return View(parkingPermit);
        }

        // POST: Permits/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ParkingPermitID,VehicleID,Number,Activated,ActivatedBy,Inactivated,InactivatedBy,InactivatedReason")] ParkingPermit parkingPermit) {
            if (ModelState.IsValid) {
                db.Entry(parkingPermit).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.VehicleID = new SelectList(db.Vehicles,"VehicleID","IssueState",parkingPermit.VehicleID);
            return View(parkingPermit);
        }

        // GET: Permits/Delete/5
        public ActionResult Delete(int? id) {
            if (id == null) {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ParkingPermit parkingPermit = db.ParkingPermits.Find(id);
            if (parkingPermit == null) {
                return HttpNotFound();
            }
            return View(parkingPermit);
        }

        // POST: Permits/Delete/5
        [HttpPost,ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id) {
            ParkingPermit parkingPermit = db.ParkingPermits.Find(id);
            db.ParkingPermits.Remove(parkingPermit);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing) {
            if (disposing) {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
