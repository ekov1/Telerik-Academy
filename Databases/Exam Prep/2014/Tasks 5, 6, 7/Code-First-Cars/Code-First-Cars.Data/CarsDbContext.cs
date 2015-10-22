namespace Code_First_Cars.Data
{
    using System.Data.Entity;
    using Migrations;
    using Models;

    public class CarsDbContext : DbContext, ICarsDbContext
    {
        private const string ConnectionString = "CodeFirstCars";

        public CarsDbContext() 
            : base(ConnectionString)
        {
            Database.SetInitializer(new DropCreateDatabaseAlways<CarsDbContext>());
            // Database.SetInitializer(new MigrateDatabaseToLatestVersion<CarsDbContext, Configuration>());
        }


        public IDbSet<Dealer> Dealers { get; set; }

        public IDbSet<Car> Cars { get; set; }

        public IDbSet<Manufacturer> Manufacturers { get; set; }

        public IDbSet<City> Cities { get; set; }

        public new void SaveChanges()
        {
            base.SaveChanges();
        }
    }
}
