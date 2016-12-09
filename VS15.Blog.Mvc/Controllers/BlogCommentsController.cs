using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using VS15.Blog.Models;

namespace VS15.Blog.Controllers {
    [RoutePrefix("api/blogcomments")]
    public class BlogCommentsController:ApiController {
        //Members
        private BlogGateway gateway = new BlogGateway();

        //Interface
        public IList<BlogCommentView> Get(int id) {
            // GET api/blogcomments/5
            //Load all comments for the specified blog

            //Load all comments (no login required)
            List<BlogCommentView> blogComments = new List<BlogCommentView>();
            BlogComment[] approvedcomments = gateway.BlogComments.Where(b => b.BlogId == id).ToArray();
            foreach (BlogComment comment in approvedcomments) {
                if (comment.ParentCommentID == null || comment.ParentCommentID < 1) {
                    //Parent comment
                    BlogComment[] replyComments = approvedcomments.Where(w => w.ParentCommentID == comment.BlogCommentID).ToArray();
                    blogComments.Add(new BlogCommentView(comment, replyComments));
                }
            }
            return blogComments.ToList();
        }

        public IQueryable<BlogComment> GetBlogComments() {
            // GET: api/blogcomments
            return gateway.BlogComments;
        }


        [ResponseType(typeof(void))]
        public IHttpActionResult PutBlogComment(int id, BlogComment blogComment) {
            // PUT: api/blogcomments/5
            if (!ModelState.IsValid) return BadRequest(ModelState);
            if (id != blogComment.BlogCommentID) return BadRequest();

            gateway.Entry(blogComment).State = EntityState.Modified;
            try {
                blogComment.TimeStamp = DateTime.Now;
                gateway.SaveChanges();
            }
            catch (DbUpdateConcurrencyException) {
                if (!BlogCommentExists(id)) 
                    return NotFound();
                else 
                    throw;
            }
            return StatusCode(HttpStatusCode.NoContent);
        }

        [ResponseType(typeof(BlogComment))]
        public IHttpActionResult PostBlogComment(BlogComment blogComment) {
            // POST: api/blogcomments
            if (!ModelState.IsValid) {
                return BadRequest(ModelState);
            }

            blogComment.TimeStamp = DateTime.Now;
            gateway.BlogComments.Add(blogComment);
            gateway.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = blogComment.BlogCommentID }, blogComment);
        }

        [ResponseType(typeof(BlogComment))]
        public IHttpActionResult DeleteBlogComment(int id) {
            // DELETE: api/blogcomments/5
            BlogComment blogComment = gateway.BlogComments.Find(id);
            if (blogComment == null) {
                return NotFound();
            }
            //Remove comment
            gateway.BlogComments.Remove(blogComment);
            if (blogComment.ParentCommentID == null) {
                //Remove all reply comments as well
                BlogComment[] replys = gateway.BlogComments.Where(bc => bc.ParentCommentID == blogComment.BlogCommentID).ToArray();
                foreach (BlogComment reply in replys) {
                    gateway.BlogComments.Remove(reply);
                }
            }
            gateway.SaveChanges();

            return Ok(blogComment);
        }

        protected override void Dispose(bool disposing) {
            if (disposing) {
                gateway.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool BlogCommentExists(int id) {
            return gateway.BlogComments.Count(e => e.BlogCommentID == id) > 0;
        }
    }
}