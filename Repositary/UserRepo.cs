using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CompanyBranding.Models;
using CompanyBranding.ViewModel;
namespace CompanyBranding.Repositary
{
    public class UserRepo
    {
        private readonly CBContext _dbContext;

        public UserRepo()
        {
            _dbContext = new CBContext();
        }

        public User GetUser( User _user)
        {
            string epwd = Encryption.Encode(_user.password);
            // cheking email id and password in database
            var result = _dbContext.Users.Where(m => m.email == _user.email && m.password == epwd).Select(m=> m).FirstOrDefault();
            return result;
        }

        public object GetDetails()
        {
          return  _dbContext.Customers.Select(m => new CustomerVM {
                id = m.id,
                name =  m.name,
                company_name = m.company_name,
                contact_person =  m.contact_person,
                 dba=  m.dba,
                email=  m.email,
                family_member =  m.family_member,
               owner_name =  m.owner_name,
                owner_percentage = m.owner_percentage,
                phone=  m.phone,
                referred_by = m.referred_by
            }).ToList();
        }

        public CustomViewModel GetDetailById(Guid id)
        {
            var _customer = _dbContext.Customers.Where(m => m.id == id).Select(m => new CustomerVM
            { 
                id = m.id,
                name = m.name,
                company_name = m.company_name,
                contact_person = m.contact_person,
                dba = m.dba,
                email = m.email,
                family_member = m.family_member,
                chbFamily = m.family_member ==null ?true : false,
                owner_name = m.owner_name,
                owner_percentage = m.owner_percentage,
                phone = m.phone,
                amount_first = m.amount_first,
                amount_second = m.amount_second,
                receiving_date_first = m.receiving_date_first,
                receiving_date_second = m.receiving_date_second,
                chbAmount1 = m.amount_first ==0 ? true :false,
                chbAmount2 = m.amount_second == 0 ?true :false,
                referred_by = m.referred_by,

                //fileUpload1_path = m.customerRecords.Where(x => x.record_id == 1).Select(x => x.filePath).FirstOrDefault(),
                //fileUpload2_path = m.customerRecords.Where(x => x.record_id == 2).Select(x => x.filePath).FirstOrDefault(),
                //fileUpload3_path = m.customerRecords.Where(x => x.record_id == 3).Select(x => x.filePath).FirstOrDefault(),
                //fileUpload4_path = m.customerRecords.Where(x => x.record_id == 4).Select(x => x.filePath).FirstOrDefault(),
                //fileUpload5_path = m.customerRecords.Where(x => x.record_id == 5).Select(x => x.filePath).FirstOrDefault(),
                //fileUpload6_path = m.customerRecords.Where(x => x.record_id == 6).Select(x => x.filePath).FirstOrDefault(),
                //fileUpload7_path = m.customerRecords.Where(x => x.record_id == 7).Select(x => x.filePath).FirstOrDefault(),
                //fileUpload8_path = m.customerRecords.Where(x => x.record_id == 8).Select(x => x.filePath).FirstOrDefault(),
                //fileUpload9_path = m.customerRecords.Where(x => x.record_id == 9).Select(x => x.filePath).FirstOrDefault(),
                //fileUpload10_path = m.customerRecords.Where(x => x.record_id == 10).Select(x => x.filePath).FirstOrDefault(),
                //fileUpload11_path = m.customerRecords.Where(x => x.record_id == 11).Select(x => x.filePath).FirstOrDefault(),
                //fileUpload12_path = m.customerRecords.Where(x => x.record_id == 12).Select(x => x.filePath).FirstOrDefault(),
                //fileUpload13_path = m.customerRecords.Where(x => x.record_id == 13).Select(x => x.filePath).FirstOrDefault(),
                //fileUpload14_path = m.customerRecords.Where(x => x.record_id == 14).Select(x => x.filePath).FirstOrDefault(),
                //fileUpload15_path = m.customerRecords.Where(x => x.record_id == 15).Select(x => x.filePath).FirstOrDefault(),
                //fileUpload16_path = m.customerRecords.Where(x => x.record_id == 16).Select(x => x.filePath).FirstOrDefault(),
                //fileUpload17_path = m.customerRecords.Where(x => x.record_id == 17).Select(x => x.filePath).FirstOrDefault(),
                //fileUpload18_path = m.customerRecords.Where(x => x.record_id == 18).Select(x => x.filePath).FirstOrDefault(),

                //chbFile1 = m.customerRecords.Where(x => x.record_id == 1).Select(x => x.filePath).FirstOrDefault() == null ? true :false,
                //chbFile2 = m.customerRecords.Where(x => x.record_id == 2).Select(x => x.filePath).FirstOrDefault() == null ? true : false,
                //chbFile3 = m.customerRecords.Where(x => x.record_id == 3).Select(x => x.filePath).FirstOrDefault() == null ? true : false,
                //chbFile4 = m.customerRecords.Where(x => x.record_id == 4).Select(x => x.filePath).FirstOrDefault() == null ? true : false,
                //chbFile5 = m.customerRecords.Where(x => x.record_id == 5).Select(x => x.filePath).FirstOrDefault() == null ? true : false,
                //chbFile6 = m.customerRecords.Where(x => x.record_id == 6).Select(x => x.filePath).FirstOrDefault() == null ? true : false,
                //chbFile7 = m.customerRecords.Where(x => x.record_id == 7).Select(x => x.filePath).FirstOrDefault() == null ? true : false,
                //chbFile8 = m.customerRecords.Where(x => x.record_id == 8).Select(x => x.filePath).FirstOrDefault() == null ? true : false,
                //chbFile9 = m.customerRecords.Where(x => x.record_id == 9).Select(x => x.filePath).FirstOrDefault() == null ? true : false,
                //chbFile10 = m.customerRecords.Where(x => x.record_id == 10).Select(x => x.filePath).FirstOrDefault() == null ? true : false,
                //chbFile11 = m.customerRecords.Where(x => x.record_id == 11).Select(x => x.filePath).FirstOrDefault() == null ? true : false,
                //chbFile12 = m.customerRecords.Where(x => x.record_id == 12).Select(x => x.filePath).FirstOrDefault() == null ? true : false,
                //chbFile13 = m.customerRecords.Where(x => x.record_id == 13).Select(x => x.filePath).FirstOrDefault() == null ? true : false,
                //chbFile14 = m.customerRecords.Where(x => x.record_id == 14).Select(x => x.filePath).FirstOrDefault() == null ? true : false,
                //chbFile15 = m.customerRecords.Where(x => x.record_id == 15).Select(x => x.filePath).FirstOrDefault() == null ? true : false,
                //chbFile16 = m.customerRecords.Where(x => x.record_id == 16).Select(x => x.filePath).FirstOrDefault() == null ? true : false,
                //chbFile17 = m.customerRecords.Where(x => x.record_id == 17).Select(x => x.filePath).FirstOrDefault() == null ? true : false,
                //chbFile18 = m.customerRecords.Where(x => x.record_id == 18).Select(x => x.filePath).FirstOrDefault() == null ? true : false,

            }).FirstOrDefault();

            var _files = _dbContext.CustomerRecords.Where(m => m.customer_id == id).Select(m => new Recordfiles
            {
                id = m.record.id,
                chbFile = m.filePath == null ? true : false,
                //fileUpload = null,
                fileUploadPath = m.filePath,
                name = m.record.name

            }).ToList();

            var _result = new CustomViewModel {CustomerVM = _customer , record=_files };

            return _result;
        }



    }
}