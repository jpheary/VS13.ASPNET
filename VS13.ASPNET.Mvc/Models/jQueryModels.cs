using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace VS13.Models {
    //
    public class Shipment {
        //Members
        [DataType(DataType.Date)]
        [Display(Name = "Shipping Date")]
        public DateTime ShipDate { get; set; }

        //Interface
        public Shipment() {
            //Constructor
            ShipDate = DateTime.Today;
        }
    }
}