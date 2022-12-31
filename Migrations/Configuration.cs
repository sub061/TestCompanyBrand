namespace CompanyBranding.Migrations
{
    using CompanyBranding.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<CompanyBranding.Models.CBContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(CompanyBranding.Models.CBContext context)
        {
            //  This method will be called after migrating to the latest version.
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
 
            records.ForEach(r => context.Records.AddOrUpdate(p => p.name , r ));
            context.SaveChanges();

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
        }
    }
}
