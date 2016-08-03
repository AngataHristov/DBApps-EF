namespace CarsSystem.ConsoleClient
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    using CarsSystem.Models;
    using CarsSystem.Models.Enums;
    using Data;
    using Models;
    using Newtonsoft.Json;

    public static class JSonClassImporter
    {
        public static void Import()
        {
            var directory = Directory.GetCurrentDirectory() + "/JsonFiles/";

            var carsToAdd = Directory
                .GetFiles(directory)
                .Where(f => f.EndsWith(".json"))
                .Select(f => File.ReadAllText(f))
                .SelectMany(str => JsonConvert.DeserializeObject<IEnumerable<CarJsonModel>>(str))
                .ToList();

            var addesCities = new HashSet<string>();
            var addedManufacturers = new HashSet<string>();

            Console.WriteLine("Adding Cars");

            var db = new CarsSystemDbContext();
            db.Configuration.AutoDetectChangesEnabled = false;

            var addedCars = 0;
            foreach (var car in carsToAdd)
            {
                var cityName = car.Dealer.City;
                if (!addesCities.Contains(cityName))
                {
                    var city = new City()
                    {
                        Name = cityName
                    };

                    addesCities.Add(cityName);
                    db.SaveChanges();
                }

                var manufacturerName = car.ManufacturerName;
                if (!addedManufacturers.Contains(manufacturerName))
                {
                    addedManufacturers.Add(manufacturerName);

                    db.Manufactures.Add(new Manufacturer()
                    {
                        Name = car.ManufacturerName
                    });

                    db.SaveChanges();
                }

                var dealerToAdd = new Dealer()
                {
                    Name = car.Dealer.Name
                };

                var dbCity = db.Cities
                    .FirstOrDefault(c => c.Name == cityName);

                dealerToAdd.Cities.Add(dbCity);

                var dbManufactorer = db.Manufactures
                    .FirstOrDefault(m => m.Name == manufacturerName);

                var carToAdd = new Car()
                {
                    Manufacturer = dbManufactorer,
                    Dealer = dealerToAdd,
                    Model = car.Model,
                    Price = car.Price,
                    TransmitionType = (TransmitionType)car.TransmitionType,
                    Year = car.Year
                };

                db.Cars.Add(carToAdd);

                if (addedCars % 100 == 0)
                {
                    Console.Write(".");
                    db.SaveChanges();
                    db.Dispose();
                    db = new CarsSystemDbContext();
                    db.Configuration.AutoDetectChangesEnabled = false;
                    db.Configuration.ValidateOnSaveEnabled = false;
                }

                addedCars++;
            }

            db.SaveChanges();
            db.Configuration.AutoDetectChangesEnabled = true;
            db.Configuration.ValidateOnSaveEnabled = true;
        }
    }
}
