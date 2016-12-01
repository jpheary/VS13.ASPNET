using System;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;


namespace VS13.Models {

    public enum GenderEnum { Male, Female }

    public class Person {
        public int ID { get; set; }
        [Required]
        public string Name { get; set; }
        [DisplayFormat(DataFormatString = "{0:MM-dd-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime Birthdate { get; set; }
        public GenderEnum Gender { get; set; }
    }
}