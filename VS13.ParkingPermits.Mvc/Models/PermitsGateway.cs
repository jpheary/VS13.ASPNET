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
            //Constructor
        }

        public System.Data.Entity.DbSet<VS13.Models.ParkingPermit> ParkingPermits { get; set; }

        public System.Data.Entity.DbSet<VS13.Models.Vehicle> Vehicles { get; set; }

        public List<string> GetStateList() {
            //Return the acronyms for all 50 states
            List<string> states = new List<string>(50);
            states.Add("AL");
            states.Add("AK");
            states.Add("AZ");
            states.Add("AR");
            states.Add("CA");
            states.Add("CO");
            states.Add("CT");
            states.Add("DE");
            states.Add("FL");
            states.Add("GA");
            states.Add("HI");
            states.Add("ID");
            states.Add("IL");
            states.Add("IN");
            states.Add("IA");
            states.Add("KS");
            states.Add("KY");
            states.Add("LA");
            states.Add("ME");
            states.Add("MD");
            states.Add("MA");
            states.Add("MI");
            states.Add("MN");
            states.Add("MS");
            states.Add("MO");
            states.Add("MT");
            states.Add("NE");
            states.Add("NV");
            states.Add("NH");
            states.Add("NJ");
            states.Add("NM");
            states.Add("NY");
            states.Add("NC");
            states.Add("ND");
            states.Add("OH");
            states.Add("OK");
            states.Add("OR");
            states.Add("PA");
            states.Add("RI");
            states.Add("SC");
            states.Add("SD");
            states.Add("TN");
            states.Add("TX");
            states.Add("UT");
            states.Add("VT");
            states.Add("VA");
            states.Add("WA");
            states.Add("WV");
            states.Add("WI");
            states.Add("WY");
            return states;
        }

    }
}
