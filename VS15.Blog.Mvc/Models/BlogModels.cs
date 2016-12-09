using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace VS15.Blog.Models {
    public class Blog {
        [Key]
        public virtual int BlogID { get; set; }
        [Required(ErrorMessage = "Title is required.")]
        public virtual string Title { get; set; }
        [Required(ErrorMessage = "Author is required.")]
        public virtual string Author { get; set; }
        [Required(ErrorMessage = "Author is required.")]
        public virtual DateTime WhenPosted { get; set; }
        [Required(ErrorMessage = "Date posted is required.")]
        public virtual string Body { get; set; }
    }

    public class BlogComment {
        [Key]
        public virtual int BlogCommentID { get; set; }
        public virtual string Author { get; set; }
        public virtual string Body { get; set; }
        public virtual DateTime WhenPosted { get; set; }
        public virtual DateTime? LastEdited { get; set; }
        public virtual int? ParentCommentID { get; set; }
        public virtual DateTime TimeStamp { get; set; }
        public int BlogId { get; set; }
        [ForeignKey("BlogId")]
        public Blog Blog { get; set; }
    }
}