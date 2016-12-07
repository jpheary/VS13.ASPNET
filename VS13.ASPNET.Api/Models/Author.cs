using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace VS13.ASPNET.Api.Models {
    public class Author {
        public int AuthorId { get; set; }
        [Required]
        public string Name { get; set; }
    }
}