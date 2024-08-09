namespace RVASProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddPriceToRental : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Rentals", "Price", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Rentals", "Price");
        }
    }
}
