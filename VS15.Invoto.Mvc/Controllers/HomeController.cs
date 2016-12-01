using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using VS15.Models;
using Newtonsoft.Json;
using System.IO;

namespace VS15 {
    public class HomeController:Controller {
        //Members
        private InvontoGateway gateway = new InvontoGateway();

        //Interface
        public ActionResult Index() {
            // GET: Permits
            return View();
        }

        [HttpGet]
        public JsonResult ViewContacts() {
            //Get a list view of all contacts
            bool proxyCreation = gateway.Configuration.ProxyCreationEnabled;
            try {
                gateway.Configuration.ProxyCreationEnabled = false;
                var contacts = gateway.Contacts.Include(c => c.Groups).ToList();
                List<Contact> _contacts = new List<Contact>();
                foreach(Contact c in contacts) {
                    foreach (Group g in c.Groups) { g.Contacts = null; }
                    _contacts.Add(c);
                }

                return Json(_contacts, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex) {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                return Json(ex.Message);
            }
            finally {
                gateway.Configuration.ProxyCreationEnabled = proxyCreation;
            }
        }

        [HttpPost]
        public JsonResult CreateContact(Contact contact) {
            //Create a new contact
            try {
                Contact con = new Contact();
                con.FirstName = contact.FirstName;
                con.LastName = contact.LastName;
                con.Email = contact.Email;
                con.Phone = contact.Phone;
                con.Birthdate = contact.Birthdate;
                con.Comments = contact.Comments;
                if(contact.Groups != null) { 
                    con.Groups = new HashSet<Group>();
                    foreach (Group g in contact.Groups) {
                        Group group = gateway.Groups.Find(g.GroupID);
                        if(group != null) con.Groups.Add(group);
                    }
                }
                gateway.Contacts.Add(con);
                gateway.SaveChanges();

                return Json(new { success = true, id = con.ContactID });
            }
            catch (Exception ex) {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                return Json(ex.Message);
            }
        }

        [HttpGet]
        public JsonResult ReadContact(int id) {
            //Get an existing contact
            bool proxyCreation = gateway.Configuration.ProxyCreationEnabled;
            try {
                gateway.Configuration.ProxyCreationEnabled = false;
                var contact = gateway.Contacts.Find(id);
                return Json(contact, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex) {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                return Json(ex.Message);
            }
            finally {
                gateway.Configuration.ProxyCreationEnabled = proxyCreation;
            }
        }

        [HttpPost]
        public JsonResult UpdateContact(Contact contact) {
            //Update an existing contact
            try {
                int id = Convert.ToInt32(contact.ContactID);
                var con = gateway.Contacts.Where(c => c.ContactID == id).Include(c => c.Groups).FirstOrDefault();
                con.FirstName = contact.FirstName;
                con.LastName = contact.LastName;
                con.Email = contact.Email;
                con.Phone = contact.Phone;
                con.Birthdate = contact.Birthdate;
                con.Comments = contact.Comments;
                con.Groups.Clear();
                if (contact.Groups != null) {
                    foreach (Group g in contact.Groups) {
                        Group group = gateway.Groups.Find(g.GroupID);
                        if (group != null) con.Groups.Add(group);
                    }
                }
                gateway.SaveChanges();

                return Json(new { success = true, data = (string)null });
            }
            catch (Exception ex) {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                return Json(ex.Message);
            }
        }

        [HttpPost]
        public JsonResult DeleteContact(Contact contact) {
            //Delete an existing contact
            try {
                //Delete the contact
                int id = Convert.ToInt32(contact.ContactID);
                var con = gateway.Contacts.Where(c => c.ContactID == id).FirstOrDefault();
                gateway.Contacts.Remove(con);
                gateway.SaveChanges();

                //Delete the profile image
                FileInfo fi = new FileInfo(Server.MapPath(contact.Profile));
                if(fi != null) fi.Delete();

                return Json(new { success = true, data = (string)null });
            }
            catch (Exception ex) {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                return Json(ex.Message);
            }
        }

        [HttpGet]
        public JsonResult ListGroups() {
            //Get a list of all groups
            try {
                var groups = gateway.Groups.ToList();

                return Json(groups, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex) {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                return Json(ex.Message);
            }
        }

        [HttpPost]
        public JsonResult UploadImage(Contact contact) {
            //Upload a contact profile image
            try {
                foreach (string file in Request.Files) {
                    var fileContent = Request.Files[file];
                    if (fileContent != null && fileContent.ContentLength > 0) {
                        var inputStream = fileContent.InputStream;
                        var filename = contact.ContactID.ToString() + "-" + contact.ProfileImage.FileName;
                        var path = Path.Combine(Server.MapPath("~/images/"), filename);
                        using (var fileStream = System.IO.File.Create(path)) {
                            inputStream.CopyTo(fileStream);
                        }
                    }
                }

                int id = Convert.ToInt32(contact.ContactID);
                var con = gateway.Contacts.Where(c => c.ContactID == id).Include(c => c.Groups).FirstOrDefault();
                con.Profile = "/images/" + contact.ContactID.ToString() + "-" + contact.ProfileImage.FileName;
                gateway.SaveChanges();

                return Json(new { success = true, profile = con.Profile });
            }
            catch (Exception ex) {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                return Json(ex.Message);
            }
        }


        public ActionResult About() {
            ViewBag.Message = "Using MVC, EF, Angular, SQL Sever, Bootstrap.";
            return View();
        }
    }
}