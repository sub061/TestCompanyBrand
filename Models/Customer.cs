using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CompanyBranding.Models
{
    [Table("customer")]
    public class Customer
    {   [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid id { get; set; }
        public string name { get; set; }
        public string company_name { get; set; }
        public string dba { get; set; }
        public string email { get; set; }
        public string phone { get; set; }
        public string owner_name { get; set; }
        public float owner_percentage { get; set; }
        public string contact_person { get; set; }
        public string family_member { get; set; }
        public string referred_by { get; set; }
        public double amount_first { get; set; }
        public DateTime? receiving_date_first { get; set; }
        public double amount_second { get; set; }
        public DateTime? receiving_date_second { get; set; }
        public virtual List<CustomerRecord> customerRecords { get; set; }
      
    }
}