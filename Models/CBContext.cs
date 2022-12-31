using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using CompanyBranding.Models;

namespace CompanyBranding.Models
{
    public class CBContext : DbContext
    {
        public CBContext(): base("name=CompanyBrandingContext")
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

        }

        public DbSet<Customer> Customers { get; set; }
    
        public DbSet<Record> Records { get; set; }
        public DbSet<CustomerRecord> CustomerRecords { get; set; }
        public DbSet<User> Users { get; set; }

    }
}