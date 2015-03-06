using System;
using System.Data.Entity;


namespace VS13.Models {
    public class Person {
        public int ID { get; set; }
        public string Name { get; set; }
        public DateTime Birthdate { get; set; }
        public string Gender { get; set; }
    }

    public class WorldDBContext:DbContext {
        public DbSet<Person> People { get; set; }
    }
}