using System;
using System.Data.Entity;
using System.Linq;

namespace VS15.Blog.Models {
    public class BlogGateway:DbContext {
        //Members

        //Interface
        public BlogGateway() : base("name=BlogGateway") {
            //Constructor
            Database.SetInitializer(new BlogGatewayDbInitializer());
        }

        public DbSet<VS15.Blog.Models.Blog> Blogs { get; set; }
        public DbSet<VS15.Blog.Models.BlogComment> BlogComments { get; set; }
    }

    public class BlogGatewayDbInitializer:DropCreateDatabaseIfModelChanges<BlogGateway> {
        //Members

        //Interface
        protected override void Seed(BlogGateway context) {
            //
            base.Seed(context);
        }
    }

}