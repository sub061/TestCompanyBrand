using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using CompanyBranding.Models;
using CompanyBranding.ViewModel;
using System.Configuration;
using System.IO;
using System.Web.ModelBinding;
using System.Net.Mail;
using HtmlAgilityPack;

namespace CompanyBranding.Repositary
{
    public class CustomerRepo
    {
        private readonly CBContext _dbContext;

        public CustomerRepo()
        {
            _dbContext = new CBContext();
        }

        public List<Recordfiles> GetRecord()
        {
            return _dbContext.Records.Select( m=> new Recordfiles { id = m.id , name = m.name }).ToList();
        }

        public bool PostCustomer(CustomViewModel _customViewModel )
        {
            var _customerVM = _customViewModel.CustomerVM;
           // var _customerFiles = _customViewModel.files;
              Customer _customer = new Customer();
            _customer.name = _customerVM.name;
            _customer.company_name = _customerVM.company_name;
            _customer.dba = _customerVM.dba;
            _customer.email = _customerVM.email;
            _customer.phone = _customerVM.phone;
            _customer.owner_name = _customerVM.owner_name;
            _customer.owner_percentage = _customerVM.owner_percentage;
            if (_customerVM.chbFamily == true)
            {
                _customer.family_member = null;
            }
            else
            {
                _customer.family_member = _customerVM.family_member;
            }

            _customer.contact_person = _customerVM.contact_person;
            _customer.referred_by = _customerVM.referred_by;





            if (_customerVM.chbAmount1 == true)
            {
                _customer.amount_first = 0;
                _customer.receiving_date_first = null;
            }
            else
            {
                _customer.amount_first = Convert.ToDouble( _customerVM.amount_first);
                _customer.receiving_date_first = _customerVM.receiving_date_first;

            }
            if (_customerVM.chbAmount2 == true)
            {
                _customer.amount_second = 0;
                _customer.receiving_date_second = null;
            }
            else
            {
                _customer.amount_second = Convert.ToDouble(_customerVM.amount_second);
                _customer.receiving_date_second = _customerVM.receiving_date_second;
            }


            _dbContext.Customers.Add(_customer);
            _dbContext.SaveChanges();

            List<CustomerRecord> _customerRecords = new List<CustomerRecord>();

            CustomerRecord customerRecord = new CustomerRecord();

            for(int i=0; i< _customViewModel.record.Count; i++)
            {
                string _filePath = null;
                customerRecord.record_id = _customViewModel.record[i].id;
                customerRecord.customer_id = _customer.id;


                bool fileStatus = _customViewModel.record[i].chbFile;
                HttpPostedFileBase _file = _customViewModel.record[i].fileUpload;
                if (fileStatus == false)
                {
                    _filePath = SaveFile(_customer.id, _file);
                }
                customerRecord.filePath = _filePath;
                _dbContext.CustomerRecords.Add(customerRecord);
                _customerRecords.Add(customerRecord);
                _dbContext.SaveChanges();

            }
            //_dbContext.CustomerRecords.AddRange(_customerRecords);
            //_dbContext.SaveChanges();
            sendEmail(_customer.id, _customer.email, _customer.name);

            return true;

        }

        public bool PutCustomer(CustomViewModel _customViewModel)

        {

            Customer _customer = _dbContext.Customers.Find(_customViewModel.CustomerVM.id);
            _customer.id = _customViewModel.CustomerVM.id;
            _customer.name = _customViewModel.CustomerVM.name;
            _customer.company_name = _customViewModel.CustomerVM.company_name;
            _customer.dba = _customViewModel.CustomerVM.dba;
            _customer.email = _customViewModel.CustomerVM.email;
            _customer.phone = _customViewModel.CustomerVM.phone;
            _customer.owner_name = _customViewModel.CustomerVM.owner_name;
            _customer.owner_percentage = _customViewModel.CustomerVM.owner_percentage;
            if (_customViewModel.CustomerVM.chbFamily == true)
            {
                _customer.family_member = null;
            }
            else
            {
                _customer.family_member = _customViewModel.CustomerVM.family_member;
            }
            
            _customer.contact_person = _customViewModel.CustomerVM.contact_person;
            _customer.referred_by = _customViewModel.CustomerVM.referred_by;

           
            

           
            if(_customViewModel.CustomerVM.chbAmount1 == true)
            {
                _customer.amount_first = 0;
                _customer.receiving_date_first = null;
            }
            else
            {
                _customer.amount_first = Convert.ToDouble(_customViewModel.CustomerVM.amount_first);
                _customer.receiving_date_first = _customViewModel.CustomerVM.receiving_date_first;

            }
            if (_customViewModel.CustomerVM.chbAmount2 == true)
            {
                _customer.amount_second =0;
                _customer.receiving_date_second = null;
            }
            else
            {
                _customer.amount_second = Convert.ToDouble(_customViewModel.CustomerVM.amount_second);
                _customer.receiving_date_second = _customViewModel.CustomerVM.receiving_date_second;
            }
       
            
           
            List<CustomerRecord> _customerRecords = new List<CustomerRecord>();

           



            for (int i = 0; i < _customViewModel.record.Count; i++)
            {
                CustomerRecord customerRecord = new CustomerRecord();
                string _filePath = null;
                customerRecord.record_id = _customViewModel.record[i].id;
                customerRecord.customer_id = _customer.id;


                bool fileStatus = _customViewModel.record[i].chbFile;
                HttpPostedFileBase _file = _customViewModel.record[i].fileUpload;
                if (fileStatus == false)
                {
                    _filePath = SaveFile(_customer.id, _file);
                }
                customerRecord.filePath = _filePath;
               
                _customerRecords.Add(customerRecord);
                

            }

            
              
            _customer.customerRecords = _customerRecords;
            _dbContext.SaveChanges();

            //_dbContext.CustomerRecords.AddRange(_customerRecords);
            //_dbContext.SaveChanges();
           // sendEmail(_customer.id, _customer.email, _customer.name);


            return true;

        }
        
        public string SaveFile(Guid _customerId , HttpPostedFileBase _file)
        {
            if (_file == null)
            {
                return null;
            } 
            else
            {
                //string _uploadPath = ConfigurationManager.AppSettings["UploadPath"].ToString();
                string _uploadPath = HttpContext.Current.Server.MapPath("~/Asset/");
                string _fileExtension = Path.GetExtension(_file.FileName);

                string _dir = _uploadPath + _customerId;
                if (!Directory.Exists(_dir))
                {
                    Directory.CreateDirectory(_dir);
                }
                string _filePath = _dir + "\\" + _file.FileName.Replace(" ", "");

                _file.SaveAs(_filePath);

                string fileName = "/Asset/" + _customerId + "/" + _file.FileName.Replace(" ", "");
                return fileName;
            }

        }


        private void sendEmail(Guid securityUserId, string emailAddressTo, string userName)
        {
            string securityId = securityUserId.ToString().Substring(0, securityUserId.ToString().IndexOf("-")).ToUpper();
            var html = new HtmlDocument();
            string templateFilePath = HttpContext.Current.Server.MapPath("~/Asset/EmailTemplate/") + "thankyou.html";
            html.Load(templateFilePath);
            var body = html.DocumentNode.SelectNodes("//body");
            var query = html.DocumentNode.SelectNodes("//a");
           
            var res = html.DocumentNode.SelectNodes("//html");
            string url = res.FirstOrDefault().OuterHtml.ToString();
            string emailbody = url.Replace("XXXUserName", userName);
           
            string emailIdFrom = ConfigurationManager.AppSettings["MailId"];
            string password = ConfigurationManager.AppSettings["Password"];
            string host = ConfigurationManager.AppSettings["host"];
            System.Net.Mail.MailMessage msg = new System.Net.Mail.MailMessage(new System.Net.Mail.MailAddress(emailIdFrom), new System.Net.Mail.MailAddress(emailAddressTo));
            msg.Subject = "Thank You.";
            msg.Body = emailbody;
            msg.IsBodyHtml = true;
            SmtpClient smtpClient = new SmtpClient();
            smtpClient.Host = host;
            smtpClient.EnableSsl = false;
            smtpClient.Port = 25;
            smtpClient.UseDefaultCredentials = true;
            smtpClient.Credentials = new System.Net.NetworkCredential(emailIdFrom, password);
            smtpClient.Send(msg);
        }

    }
}