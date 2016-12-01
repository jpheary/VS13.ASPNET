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
    public class WorldController:Controller {
        //Members
        private WorldGateway gateway = new WorldGateway();

        //Interface
        public ActionResult Index() {
            // GET: World
            return View(gateway.People.ToList());
        }

        public ActionResult Create() {
            // GET: World/Create
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name,Birthdate,Gender")] Person person) {
            // POST: World/Create
            // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
            // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
            if (ModelState.IsValid) {
                gateway.People.Add(person);
                gateway.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(person);
        }


        public ActionResult Read(int? id) {
            // GET: World/Details/5
            if (id == null) {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Person person = gateway.People.Find(id);
            if (person == null) {
                return HttpNotFound();
            }
            return View(person);
        }


        public ActionResult Edit(int? id) {
            // GET: World/Edit/5
            if (id == null) {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Person person = gateway.People.Find(id);
            if (person == null) {
                return HttpNotFound();
            }
            return View(person);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,Birthdate,Gender")] Person person) {
            // POST: World/Edit/5
            // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
            // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
            if (ModelState.IsValid) {
                gateway.Entry(person).State = EntityState.Modified;
                gateway.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(person);
        }


        [HttpPost,ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id) {
            // POST: World/Delete/5
            Person person = gateway.People.Find(id);
            gateway.People.Remove(person);
            gateway.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing) {
            if (disposing) {
                gateway.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
