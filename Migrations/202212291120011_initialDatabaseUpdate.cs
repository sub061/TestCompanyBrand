namespace CompanyBranding.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initialDatabaseUpdate : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.customer_ppp", "customer_id", "dbo.customer");
            DropIndex("dbo.customer_ppp", new[] { "customer_id" });
            AddColumn("dbo.customer", "amount_first", c => c.Double(nullable: false));
            AddColumn("dbo.customer", "receiving_date_first", c => c.DateTime());
            AddColumn("dbo.customer", "amount_second", c => c.Double(nullable: false));
            AddColumn("dbo.customer", "receiving_date_second", c => c.DateTime());
            DropTable("dbo.customer_ppp");
        }
        
        public override void Down()
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
                .PrimaryKey(t => t.id);
            
            DropColumn("dbo.customer", "receiving_date_second");
            DropColumn("dbo.customer", "amount_second");
            DropColumn("dbo.customer", "receiving_date_first");
            DropColumn("dbo.customer", "amount_first");
            CreateIndex("dbo.customer_ppp", "customer_id");
            AddForeignKey("dbo.customer_ppp", "customer_id", "dbo.customer", "id", cascadeDelete: true);
        }
    }
}
