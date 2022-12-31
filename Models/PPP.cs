using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CompanyBranding.Models
{
    [Table("customer_ppp")]
    public class CustomerPPP
    {
        [Key]
        public int id { get; set; }
       
        public double amount_first { get; set; }
        public DateTime? receiving_date_first { get; set; }
        public double amount_second { get; set; }
        public DateTime? receiving_date_second { get; set; }

        public Guid customer_id { get; set; }
        public  Customer customer { get; set; }
    }
}