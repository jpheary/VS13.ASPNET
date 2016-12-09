using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using VS15.Blog.Models;

namespace VS15.Blog.Controllers {
    //
    public class BlogsController:ApiController {
        //Members
        private BlogGateway gateway = new BlogGateway();

        //Interface
        public IQueryable<Models.Blog> ViewBlogs() {
            // GET: api/Blogs
            return gateway.Blogs;
        }

        [ResponseType(typeof(Models.Blog))]
        public IHttpActionResult GetBlog(int id) {
            // GET: api/Blogs/5
            Models.Blog blog = gateway.Blogs.Find(id);
            if (blog == null) {
                return NotFound();
            }

            return Ok(blog);
        }

        [ResponseType(typeof(void))]
        public IHttpActionResult PutBlog(int id, Models.Blog blog) {
            // PUT: api/Blogs/5
            if (!ModelState.IsValid) return BadRequest(ModelState);
            if (id != blog.BlogID) return BadRequest();

            gateway.Entry(blog).State = EntityState.Modified;
            try {
                gateway.SaveChanges();
            }
            catch (DbUpdateConcurrencyException) {
                if (!BlogExists(id)) {
                    return NotFound();
                }
                else {
                    throw;
                }
            }
            return StatusCode(HttpStatusCode.NoContent);
        }

        [ResponseType(typeof(Models.Blog))]
        public IHttpActionResult PostBlog(Models.Blog blog) {
            // POST: api/Blogs
            if (!ModelState.IsValid) {
                return BadRequest(ModelState);
            }

            gateway.Blogs.Add(blog);
            gateway.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = blog.BlogID }, blog);
        }

        [ResponseType(typeof(Models.Blog))]
        public IHttpActionResult DeleteBlog(int id) {
            // DELETE: api/Blogs/5
            Models.Blog blog = gateway.Blogs.Find(id);
            if (blog == null) {
                return NotFound();
            }

            gateway.Blogs.Remove(blog);
            gateway.SaveChanges();

            return Ok(blog);
        }

        protected override void Dispose(bool disposing) {
            if (disposing) {
                gateway.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool BlogExists(int id) {
            return gateway.Blogs.Count(e => e.BlogID == id) > 0;
        }
    }
}