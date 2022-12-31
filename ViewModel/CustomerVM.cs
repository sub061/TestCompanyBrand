using CompanyBranding.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CompanyBranding.ViewModel
{
    public class CustomerVM
    {
        public Guid id { get; set; }
        [Required(ErrorMessage ="Please enter name")]
        public string name { get; set; }
        [Required(ErrorMessage = "Please enter company name")]
        public string company_name { get; set; }
        public string dba { get; set; }
        [Required(ErrorMessage = "Please enter email")]
        public string email { get; set; }
        [Required(ErrorMessage = "Please enter phone number")]
        public string phone { get; set; }
        [Required(ErrorMessage = "Please enter owner name")]
        public string owner_name { get; set; }
        [Required(ErrorMessage = "Please enter owner percentage")]
        public float owner_percentage { get; set; }
        public string family_member { get; set; }
        public bool chbFamily { get; set; }
        public string contact_person { get; set; }
        [Required(ErrorMessage = "Please enter referred by")]
        public string referred_by { get; set; }

        public double? amount_first { get; set; }
        public DateTime? receiving_date_first { get; set; }
        
        public bool chbAmount1 { get; set; }
        public double? amount_second { get; set; }
  
        public DateTime? receiving_date_second { get; set; }

        public bool chbAmount2 { get; set; }

     
    }
}