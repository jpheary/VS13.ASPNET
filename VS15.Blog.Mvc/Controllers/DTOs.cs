using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VS15.Blog.Models;

namespace VS15.Blog.Controllers {
    public class BlogCommentView {
        //Instance
        private BlogComment mComment = null;
        private List<BlogCommentView> mReplyComments = null;

        public BlogCommentView(BlogComment comment, BlogComment[] replyComments) {
            //Constructor
            this.mComment = comment;

            this.mReplyComments = new List<BlogCommentView>();
            if (replyComments != null) {
                foreach (BlogComment replycomment in replyComments) {
                    this.mReplyComments.Add(new BlogCommentView(replycomment, null));
                }
            }
        }
        public long BlogCommentID { get { return this.mComment.BlogCommentID; } }
        public string Author { get { return this.mComment.Author; } }
        public bool IsBlogAdmin { get { return this.mComment.IsBlogAdmin; } }
        public string Body { get { return this.mComment.Body; } }
        public string WhenPosted { get { return this.mComment.WhenPosted.ToString("MM/dd/yyyy HH:mm"); } }
        public string LastEdited { get { return this.mComment.LastEdited != null ? this.mComment.LastEdited.GetValueOrDefault().ToString("MM/dd/yyyy HH:mm") : ""; } }
        public long EditedBy { get { return this.mComment.EditedBy != null ? this.mComment.EditedBy.GetValueOrDefault() : 0; } }
        public long ResponseToComment { get { return this.mComment.ResponseToComment ?? 0; } }
        public string TimeStamp { get { return this.mComment.TimeStamp.ToString("MM/dd/yyyy HH:mm:ss"); } }
        public bool IsApproved { get { return this.mComment.IsApproved; } }
        public long BlogId { get { return this.mComment.BlogId; } }
        public List<BlogCommentView> ReplyComments { get { return this.mReplyComments; } }
        public string Editor { get { return ""; } }
    }
}