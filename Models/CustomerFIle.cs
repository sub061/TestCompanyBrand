using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CompanyBranding.Models
{
    [Table("customer_records")]
    public class CustomerRecord
    {
        [Key]
        public int id { get; set; }
        public Guid customer_id { get; set; }
        [ForeignKey("customer_id")]
        public virtual Customer customer { get; set; }
        public int record_id { get; set; }
        [ForeignKey("record_id")]
        public virtual Record record { get; set; }

        public string filePath { get; set; }

    }
}