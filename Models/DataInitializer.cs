using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CompanyBranding.Models
{
    public class DataInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<CBContext>
    {
        protected override void Seed(CBContext context)
        {
            var records = new List<Record>
            {
            new Record{name ="Federal Payroll Tax Return (941s) for Quarter 1 2020"},
            new Record{name ="Federal Payroll Tax Return (941s) for Quarter 2 2020"},
            new Record{name ="Federal Payroll Tax Return (941s) for Quarter 3 2020"},
            new Record{name ="Federal Payroll Tax Return (941s) for Quarter 4 2020"},
            new Record{name ="Federal Payroll Tax Return (941s) for Quarter 1 2021"},
            new Record{name ="Federal Payroll Tax Return (941s) for Quarter 2 2021"},
            new Record{name ="Federal Payroll Tax Return (941s) for Quarter 3 2021"},
            new Record{name ="Federal Payroll Tax Return (941s) for Quarter 4 2021"},
            new Record{name ="State Payroll Tax Return (941s) for Quarter 1 2020"},
            new Record{name ="State Payroll Tax Return (941s) for Quarter 2 2020"},
            new Record{name ="State Payroll Tax Return (941s) for Quarter 3 2020"},
            new Record{name ="State Payroll Tax Return (941s) for Quarter 4 2020"},
            new Record{name ="State Payroll Tax Return (941s) for Quarter 1 2021"},
            new Record{name ="State Payroll Tax Return (941s) for Quarter 2 2021"},
            new Record{name ="State Payroll Tax Return (941s) for Quarter 3 2021"},
            new Record{name ="State Payroll Tax Return (941s) for Quarter 4 2021"},
            new Record{name ="Employees Quarterly Reports (RT6s) for 2020"},
            new Record{name ="Employees Quarterly Reports (RT6s) for 2021"},

            };

            records.ForEach(r => context.Records.Add(r));
            context.SaveChanges();
           
        }
    }
}