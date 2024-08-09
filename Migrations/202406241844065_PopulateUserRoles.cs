namespace RVASProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateUserRoles : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO dbo.AspNetRoles VALUES(1, 'Admin')");
            Sql("INSERT INTO dbo.AspNetRoles VALUES(2, 'User')");
        }

        
        public override void Down()
        {
        }
    }
}
