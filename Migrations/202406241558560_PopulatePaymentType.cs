namespace RVASProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulatePaymentType : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO dbo.PaymentTypes VALUES(0, 'Cash')");
            Sql("INSERT INTO dbo.PaymentTypes VALUES(1, 'Debit Cards')");
            Sql("INSERT INTO dbo.PaymentTypes VALUES(2, 'Bank Transfer')");
            Sql("INSERT INTO dbo.PaymentTypes VALUES(3, 'PayPal')");
        }
        
        public override void Down()
        {
        }
    }
}
