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

            var citiesHash = new HashSet<string>();
            var manuHash = new HashSet<string>();

            foreach (var car in cars)
            {
                var city = car.Dealer.City;
                var manu = car.ManufacturerName;

                if (!citiesHash.Contains(city))
                {
                    citiesHash.Add(city);
                }

                if (!manuHash.Contains(manu))
                {
                    manuHash.Add(manu);
                }



            }

            data.SaveChanges();
        }
    }
}
