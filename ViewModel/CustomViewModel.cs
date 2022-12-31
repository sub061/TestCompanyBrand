using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CompanyBranding.Models;

namespace CompanyBranding.ViewModel
{
    public class CustomViewModel
    {
        public CustomerVM CustomerVM { get; set; }
        public   List< Recordfiles>  record { get; set; }
    }

    public class Recordfiles
    {
        public int id { get; set; }
        public string name { get; set; }
        public HttpPostedFileBase fileUpload { get; set; }
        public string fileUploadPath { get; set; }
        public bool chbFile { get; set; }

    }
}