using System;
using System.Data.Entity;
using System.Linq;

namespace VS15.Models {
    public class InvontoGateway:DbContext {
        //
        public InvontoGateway() : base("name=InvontoGateway") { }

        public DbSet<VS15.Models.Contact> Contacts { get; set; }

        public DbSet<VS15.Models.Group> Groups { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder) {
            modelBuilder.Entity<Group>().
              HasMany(g => g.Contacts).
              WithMany(c => c.Groups).
              Map(
               m => {
                   m.MapLeftKey("GroupID");
                   m.MapRightKey("ContactID");
                   m.ToTable("ContactsGroups");
               });
        }

    }
}