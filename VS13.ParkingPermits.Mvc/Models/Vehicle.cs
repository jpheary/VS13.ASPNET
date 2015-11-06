using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace VS13.Models {
    //
    public class Vehicle {
        //Members
        public virtual int VehicleID { get; set; }
        [Display(Name = "State")]
        public virtual string IssueState { get; set; }
        [Display(Name = "Plate#")]
        [Required(ErrorMessage = "License plate is required.")]
        public virtual string PlateNumber { get; set; }
        [Required(ErrorMessage = "Vehicle year is required.")]
        public virtual string Year { get; set; }
        [Required(ErrorMessage = "Vehicle make is required.")]
        public virtual string Make { get; set; }
        [Required(ErrorMessage = "Vehicle model is required.")]
        public virtual string Model { get; set; }
        [Required(ErrorMessage = "Vehicle color is required.")]
        public virtual string Color { get; set; }
        [Display(Name = "Last Name")]
        [Required(ErrorMessage = "Last name is required.")]
        public virtual string ContactLastName { get; set; }
        [Display(Name = "First Name")]
        [Required(ErrorMessage = "First name is required.")]
        public virtual string ContactFirstName { get; set; }
        [Display(Name = "Middle")]
        public virtual string ContactMiddleName { get; set; }
        [Display(Name = "Phone")]
        [Required(ErrorMessage = "Phone number is required.")]
        public virtual string ContactPhoneNumber { get; set; }
        public virtual int BadgeNumber { get; set; }
    }
}