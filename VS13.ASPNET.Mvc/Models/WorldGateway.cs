using System;
using System.Data.Entity;


namespace VS13.Models {
    public class WorldGateway:DbContext {
        //Members

        //Interface
        public WorldGateway() : base("name=WorldGateway") {
            //Constructor
            Database.SetInitializer(new WorldGatewayDbInitializer());
        }
        public DbSet<VS13.Models.Person> People { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder) {
            //
        }
    }

    public class WorldGatewayDbInitializer:System.Data.Entity.DropCreateDatabaseIfModelChanges<WorldGateway> {
        //Members

        //Interface
        protected override void Seed(WorldGateway context) {
            //
            context.People.Add(
                new Person {
                    Name = "James P Heary",
                    Birthdate = new DateTime(1961, 8, 2),
                    Gender = GenderEnum.Male
                }
            );
            base.Seed(context);
        }
    }

}