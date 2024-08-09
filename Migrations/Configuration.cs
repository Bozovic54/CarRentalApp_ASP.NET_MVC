namespace RVASProject.Migrations
{ 
    using System.Data.Entity.Migrations;


    internal sealed class Configuration : DbMigrationsConfiguration<RVASProject.Data.RentACarContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(RVASProject.Data.RentACarContext _context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
        }
    }
}
