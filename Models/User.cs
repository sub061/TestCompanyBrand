using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CompanyBranding.Models
{
    [Table("user")]
    public class User
    {
        [Key]
        public int id { get; set; }
        [Required(ErrorMessage ="Please provide Email")]
        public string email { get; set; }
        public string password { get; set; }
        public DateTime createdDate { get; set; }
    }
}