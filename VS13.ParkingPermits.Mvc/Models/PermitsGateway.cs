using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace VS13.Models {
    public class PermitsGateway:DbContext {
        // You can add custom code to this file. Changes will not be overwritten.
        // If you want Entity Framework to drop and regenerate your database automatically whenever you change your model schema, please use data migrations.

        public PermitsGateway() : base("name=PermitsGateway") {
        }

        public System.Data.Entity.DbSet<VS13.Models.ParkingPermit> ParkingPermits { get; set; }

        public System.Data.Entity.DbSet<VS13.Models.Vehicle> Vehicles { get; set; }

    }
}
