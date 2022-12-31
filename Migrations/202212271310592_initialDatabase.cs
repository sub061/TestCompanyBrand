namespace CompanyBranding.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initialDatabase : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.customer_ppp",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        customer_id = c.Guid(nullable: false),
                        amount_first = c.Double(nullable: false),
                        receiving_date_first = c.DateTime(),
                        amount_second = c.Double(nullable: false),
                        receiving_date_second = c.DateTime(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.customer", t => t.customer_id, cascadeDelete: true)
                .Index(t => t.customer_id);
            
            CreateTable(
                "dbo.customer",
                c => new
                    {
                        id = c.Guid(nullable: false, identity: true),
                        name = c.String(),
                        company_name = c.String(),
                        dba = c.String(),
                        email = c.String(),
                        phone = c.String(),
                        owner_name = c.String(),
                        owner_percentage = c.Single(nullable: false),
                        contact_person = c.String(),
                        family_member = c.String(),
                        referred_by = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.customer_records",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        customer_id = c.Guid(nullable: false),
                        record_id = c.Int(nullable: false),
                        filePath = c.String(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.customer", t => t.customer_id, cascadeDelete: true)
                .ForeignKey("dbo.record", t => t.record_id, cascadeDelete: true)
                .Index(t => t.customer_id)
                .Index(t => t.record_id);
            
            CreateTable(
                "dbo.record",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        name = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.user",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        email = c.String(nullable: false),
                        password = c.String(),
                        createdDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.customer_ppp", "customer_id", "dbo.customer");
            DropForeignKey("dbo.customer_records", "record_id", "dbo.record");
            DropForeignKey("dbo.customer_records", "customer_id", "dbo.customer");
            DropIndex("dbo.customer_records", new[] { "record_id" });
            DropIndex("dbo.customer_records", new[] { "customer_id" });
            DropIndex("dbo.customer_ppp", new[] { "customer_id" });
            DropTable("dbo.user");
            DropTable("dbo.record");
            DropTable("dbo.customer_records");
            DropTable("dbo.customer");
            DropTable("dbo.customer_ppp");
        }
    }
}
