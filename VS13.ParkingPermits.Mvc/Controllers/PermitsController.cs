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
        //Members
        private PermitsGateway db = new PermitsGateway();

        public ActionResult Index() {
            // GET: Permits
            var parkingPermits = db.ParkingPermits.Include(p => p.Vehicle);
            return View(parkingPermits.ToList());
        }

        public ActionResult Details(int? id) {
            // GET: Permits/Details/5
            if (id == null) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            ParkingPermit parkingPermit = db.ParkingPermits.Find(id);
            if (parkingPermit == null) return HttpNotFound();
            return PartialView(parkingPermit);
        }

        public ActionResult Register() {
            // GET: Permits/Register
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register([Bind(Include = "ParkingPermitID,VehicleID,Number,Activated,ActivatedBy,Vehicle")] ParkingPermit parkingPermit) {
            // POST: Permits/Register
            if (ModelState.IsValid) {
                parkingPermit.Activated = DateTime.Now;
                parkingPermit.ActivatedBy = Environment.UserName;
                db.ParkingPermits.Add(parkingPermit);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(parkingPermit);
        }

        [HttpGet]
        public string ValidatePermitNumber(string number) {
            //Validate that the specified permit number is not is use
            List<ParkingPermit> permits = db.ParkingPermits.Where(p => p.Number == number).ToList();
            if (permits.Count > 0)
                return "Permit# " + number + " is in use; please enter a new permit number.";
            else
                return "";
        }

        [HttpGet]
        public string ValidateVehiclePlateNumber(string number) {
            //Validate that the specified license plate is not on an 'active' permit
            //TODO: Modifiy this to find plate on 'active' permit not all permits
            List<Vehicle> vehicles = db.Vehicles.Where(v => v.PlateNumber == number).ToList();
            if (vehicles.Count > 0)
                return "Vehicle license plate " + vehicles[0].IssueState + " " + vehicles[0].PlateNumber + " is in use; please enter another license plate.";
            else
                return "";
        }

        public ActionResult Replace(int? id) {
            // GET: Permits/Replace permit
            if (id == null) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            ParkingPermit parkingPermit = db.ParkingPermits.Find(id);
            if (parkingPermit == null) return HttpNotFound();
            //TODO
            return View(parkingPermit);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Replace([Bind(Include = "ParkingPermitID, Number, InactivatedReason")] ParkingPermit parkingPermit) {
            // POST: Permits/Replace permit
            if (ModelState.IsValid) {
                //Inactivate current permit
                db.Entry(parkingPermit).State = EntityState.Modified;
                db.SaveChanges();

                //TODO: Create new permit


                return RedirectToAction("Index");
            }
            return View(parkingPermit);
        }

        public ActionResult Revoke(int? id) {
            // GET: Permits/Revoke permit
            if (id == null) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            ParkingPermit parkingPermit = db.ParkingPermits.Find(id);
            if (parkingPermit == null) return HttpNotFound();
            
            return View(parkingPermit);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Revoke([Bind(Include = "ParkingPermitID, InactivatedReason")] ParkingPermit parkingPermit) {
            // POST: Permits/Revoke permit
            if (ModelState.IsValid) {
                //Inactivate current permit
                db.Entry(parkingPermit).State = EntityState.Modified;
                db.SaveChanges();

                return RedirectToAction("Index");
            }
            return View(parkingPermit);
        }

        public ActionResult Change(int? id) {
            // GET: Permits/Change vehicle
            if (id == null) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            ParkingPermit parkingPermit = db.ParkingPermits.Find(id);
            if (parkingPermit == null) return HttpNotFound();

            return View(parkingPermit);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Change([Bind(Include = "ParkingPermitID,VehicleID,Number,Activated,ActivatedBy,Vehicle")] ParkingPermit parkingPermit) {
            // POST: Permits/Change vehicle
            try { 
                if (ModelState.IsValid) {
                    db.Entry(parkingPermit.Vehicle).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex) { ModelState.AddModelError("", ex.Message); }
            return View(parkingPermit);
        }

        public ActionResult Edit(int? id) {
            // GET: Permits/Edit/5
            if (id == null) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            ParkingPermit parkingPermit = db.ParkingPermits.Find(id);
            if (parkingPermit == null) return HttpNotFound();
            ViewBag.VehicleID = new SelectList(db.Vehicles,"VehicleID","IssueState",parkingPermit.VehicleID);
            return View(parkingPermit);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ParkingPermitID,VehicleID,Number,Activated,ActivatedBy,Inactivated,InactivatedBy,InactivatedReason")] ParkingPermit parkingPermit) {
            // POST: Permits/Edit/5
            // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
            // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
            if (ModelState.IsValid) {
                db.Entry(parkingPermit).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.VehicleID = new SelectList(db.Vehicles,"VehicleID","IssueState",parkingPermit.VehicleID);
            return View(parkingPermit);
        }

        public ActionResult Delete(int? id) {
            // GET: Permits/Delete/5
            if (id == null) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            ParkingPermit parkingPermit = db.ParkingPermits.Find(id);
            if (parkingPermit == null) return HttpNotFound();
            return View(parkingPermit);
        }

        [HttpPost,ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id) {
            // POST: Permits/Delete/5
            ParkingPermit parkingPermit = db.ParkingPermits.Find(id);
            db.ParkingPermits.Remove(parkingPermit);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing) {
            if (disposing) { db.Dispose(); }
            base.Dispose(disposing);
        }
    }
}
