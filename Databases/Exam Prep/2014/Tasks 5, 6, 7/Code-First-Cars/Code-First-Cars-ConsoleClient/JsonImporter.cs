namespace Code_First_Cars_ConsoleClient
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using Code_First_Cars.Data;
    using Code_First_Cars.Models;
    using Models;
    using Newtonsoft.Json;

    public class JsonImporter
    {
        private const string JsonFolder = "../../Data.Json.Files/";

        public static void Import(CarsDbContext data)
        {
            data.Configuration.AutoDetectChangesEnabled = false;
            data.Configuration.ValidateOnSaveEnabled = false;

            var files = Directory.GetFiles(JsonFolder).Select(x => x).Where(x => Path.GetExtension(x) == ".json").ToList();

            Console.WriteLine("Importing json data into SQL");

            var cars = files.Select(f => File.ReadAllText(f))
                .SelectMany(json => JsonConvert.DeserializeObject<IEnumerable<CarJson>>(json))
                .ToList();

            var cities = cars.Select(x => x.Dealer.City).Distinct().ToList();

            var manufacturers = cars.Select(x => x.ManufacturerName).Distinct().ToList();

            foreach (var city in cities)
            {
                data.Cities.Add(new City
                {
                    Name = city
                });

                data.SaveChanges();
            }

            foreach (var manufacturer in manufacturers)
            {
                data.Manufacturers.Add(new Manufacturer
                {
                    Name = manufacturer
                });

                data.SaveChanges();
            }

            data.Dispose();
            data = new CarsDbContext();

            data.Configuration.AutoDetectChangesEnabled = false;
            data.Configuration.ValidateOnSaveEnabled = false;

            var citiesFromDb = data.Cities.ToList();
            var manuFromDb = data.Manufacturers.ToList();

            foreach (var car in cars)
            {
                var dealerCity = citiesFromDb.FirstOrDefault(x => x.Name == car.Dealer.City).Id;

                var manu = manuFromDb.FirstOrDefault(x => x.Name == car.ManufacturerName).Id;

                data.Cars.Add(new Car
                {
                    Year = car.Year,
                    Model = car.Model,
                    ManufacturerId = manu,
                    Price = car.Price,
                    TransmissionType = (TransmissionType)car.TransmissionType,
                    Dealer = new Dealer
                    {
                        Name = car.Dealer.Name,
                        CityId = dealerCity
                    }
                });
            }

            data.SaveChanges();
        }
    }
}
