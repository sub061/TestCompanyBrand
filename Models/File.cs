using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CompanyBranding.Models
{   
    [Table("record")]
    public class Record
    {
        [Key]
        public int id { get; set; }
        public string name { get; set; }
    }
}