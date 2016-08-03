namespace CarsSystem.Data
{
    using System.Data.Entity;

    using CarsSystem.Data.Migrations;
    using CarsSystem.Models;

    public class CarsSystemDbContext : DbContext
    {
        public CarsSystemDbContext()
            : base("name=CarsSystem")
        {
            Database.SetInitializer(
                new MigrateDatabaseToLatestVersion<CarsSystemDbContext, Configuration>());
        }

        public virtual IDbSet<Car> Cars { get; set; }

        public virtual IDbSet<City> Cities { get; set; }

        public virtual IDbSet<Dealer> Dealers { get; set; }

        public virtual IDbSet<Manufacturer> Manufactures { get; set; }
    }
}
