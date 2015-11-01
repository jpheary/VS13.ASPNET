using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace VS13.Models {
    //
    public class FromToDates {
        //Members
        [DataType(DataType.Date)]
        [Display(Name = "From Date")]
        public DateTime FromDate { get; set; }
        [DataType(DataType.Date)]
        [Display(Name = "To Date")]
        public DateTime ToDate { get; set; }

        //Interface
        public FromToDates() {
            //Constructor
            FromDate = DateTime.Today;
            ToDate = DateTime.Today;
        }
    }

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