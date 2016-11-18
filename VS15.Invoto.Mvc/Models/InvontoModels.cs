using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace VS15.Models {
    //
    public class Contact {
        //Members
        [Key]
        public virtual int ContactID { get; set; }

        [Required(ErrorMessage = "First name is required.")]
        public virtual string FirstName { get; set; }

        [Required(ErrorMessage = "Last name is required.")]
        public virtual string LastName { get; set; }

        [Required(ErrorMessage = "Email is required.")]
        [DataType(DataType.EmailAddress)]
        public virtual string Email { get; set; }

        [DataType(DataType.PhoneNumber)]
        public virtual string Phone { get; set; }

        [DataType(DataType.Date)]
        public virtual string Birthdate { get; set; }

        public virtual string Profile { get; set; }

        [NotMapped]
        public virtual HttpPostedFileBase ProfileImage { get; set; }

        public virtual ICollection<Group> Groups { get; set; }

        [MaxLength(2000)]
        public virtual string Comments { get; set; }
    }

    public class Group {
        //Members
        [Key]
        public virtual int GroupID { get; set; }
        public virtual string Name { get; set; }
        public ICollection<Contact> Contacts { get; set; }
    }

}