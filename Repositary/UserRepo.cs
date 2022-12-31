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

        public User GetUser(User _user)
        {
            string epwd = Encryption.Encode(_user.password);
            // cheking email id and password in database
            var result = _dbContext.Users.Where(m => m.email == _user.email && m.password == epwd).Select(m => m).FirstOrDefault();
            return result;
        }

        public object GetDetails()
        {
            return _dbContext.Customers.Select(m => new CustomerVM
            {
                id = m.id,
                name = m.name,
                company_name = m.company_name,
                contact_person = m.contact_person,
                dba = m.dba,
                email = m.email,
                family_member = m.family_member,
                owner_name = m.owner_name,
                owner_percentage = m.owner_percentage,
                phone = m.phone,
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
                chbFamily = m.family_member == null ? true : false,
                owner_name = m.owner_name,
                owner_percentage = m.owner_percentage,
                phone = m.phone,
                amount_first = m.amount_first,
                amount_second = m.amount_second,
                receiving_date_first = m.receiving_date_first,
                receiving_date_second = m.receiving_date_second,
                chbAmount1 = m.amount_first == 0 ? true : false,
                chbAmount2 = m.amount_second == 0 ? true : false,
                referred_by = m.referred_by
            }).FirstOrDefault();
            var _files = _dbContext.CustomerRecords.Where(m => m.customer_id == id).Select(m => new Recordfiles
            {
                id = m.record.id,
                chbFile = m.filePath == null ? true : false,
                fileUploadPath = m.filePath,
                name = m.record.name
            }).ToList();
            var _result = new CustomViewModel { CustomerVM = _customer, record = _files };
            return _result;
        }



    }
}