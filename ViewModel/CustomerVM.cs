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
        [Required(ErrorMessage = "Please enter family members on payroll")]
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

        //public HttpPostedFileBase fileUpload1 { get; set; }
        //public string fileUpload1_path { get; set; }

        //public bool chbFile1 { get; set; }

        //public HttpPostedFileBase fileUpload2 { get; set; }
        //public string fileUpload2_path { get; set; }
        //public bool chbFile2 { get; set; }

        //public HttpPostedFileBase fileUpload3 { get; set; }
        //public string fileUpload3_path { get; set; }
        //public bool chbFile3 { get; set; }
        //public HttpPostedFileBase fileUpload4 { get; set; }
        //public string fileUpload4_path { get; set; }
        //public bool chbFile4 { get; set; }
        //public HttpPostedFileBase fileUpload5 { get; set; }
        //public string fileUpload5_path { get; set; }
        //public bool chbFile5 { get; set; }
        //public HttpPostedFileBase fileUpload6 { get; set; }
        //public string fileUpload6_path { get; set; }
        //public bool chbFile6 { get; set; }
        //public HttpPostedFileBase fileUpload7 { get; set; }
        //public string fileUpload7_path { get; set; }
        //public bool chbFile7 { get; set; }
        //public HttpPostedFileBase fileUpload8 { get; set; }
        //public string fileUpload8_path { get; set; }
        //public bool chbFile8 { get; set; }
        //public HttpPostedFileBase fileUpload9 { get; set; }
        //public string fileUpload9_path { get; set; }
        //public bool chbFile9 { get; set; }
        //public HttpPostedFileBase fileUpload10 { get; set; }
        //public string fileUpload10_path { get; set; }
        //public bool chbFile10 { get; set; }
        //public HttpPostedFileBase fileUpload11 { get; set; }
        //public string fileUpload11_path { get; set; }
        //public bool chbFile11 { get; set; }
        //public HttpPostedFileBase fileUpload12 { get; set; }
        //public string fileUpload12_path { get; set; }
        //public bool chbFile12 { get; set; }
        //public HttpPostedFileBase fileUpload13 { get; set; }
        //public string fileUpload13_path { get; set; }
        //public bool chbFile13 { get; set; }
        //public HttpPostedFileBase fileUpload14 { get; set; }
        //public string fileUpload14_path { get; set; }
        //public bool chbFile14 { get; set; }
        //public HttpPostedFileBase fileUpload15 { get; set; }
        //public string fileUpload15_path { get; set; }
        //public bool chbFile15 { get; set; }
        //public HttpPostedFileBase fileUpload16 { get; set; }
        //public string fileUpload16_path { get; set; }
        //public bool chbFile16 { get; set; }
        //public HttpPostedFileBase fileUpload17 { get; set; }
        //public string fileUpload17_path { get; set; }
        //public bool chbFile17 { get; set; }
        //public HttpPostedFileBase fileUpload18 { get; set; }
        //public string fileUpload18_path { get; set; }
        //public bool chbFile18 { get; set; }
    }
}