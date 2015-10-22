namespace Code_First_Cars.Data
{
    using System.Data.Entity;
    using Models;

    public interface ICarsDbContext
    {
        IDbSet<Dealer> Dealers { get; set; }

        IDbSet<Car> Cars { get; set; }

        IDbSet<Manufacturer> Manufacturers { get; set; }

        IDbSet<City> Cities { get; set; }

        void SaveChanges();
    }
}
