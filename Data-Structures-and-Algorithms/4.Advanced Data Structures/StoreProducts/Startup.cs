namespace StoreProducts
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using Extensions;
    using Wintellect.PowerCollections;

    public static class Startup
    {
        private const string ProductsPath = "../../Files/products.txt";

        public static void Main()
        {
            var prodBag = new OrderedBag<Product>();

            Console.WriteLine("Generating products data...");
            RandomDataGenerator.GenerateProducts(500000, ProductsPath);

            var products = File.ReadAllLines(ProductsPath);

            Console.WriteLine("Reading products data...");
            foreach (var product in products)
            {
                var productParts = product.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                var productName = productParts[0];
                var productPrice = decimal.Parse(productParts[1]);

                prodBag.Add(new Product { Name = productName, Price = productPrice });
            }

            Console.Write("Querying products data...");
            for (int i = 0; i < 10000; i++)
            {
                var minPrice = RandomExtensions.GetDecimal(1, 990);
                var maxPrice = RandomExtensions.GetDecimal((int) minPrice, 999);

                if (i % 100 == 0)
                {
                    Console.Write(".");   
                }

                FindTop20MostExpensiveProducts(prodBag, minPrice, maxPrice);
            }

            Console.WriteLine("\n\rQuerying of 10000 random prices in random ranges complete!");
        }

        private static IEnumerable<Product> FindTop20MostExpensiveProducts(OrderedBag<Product> bag, decimal min, decimal max)
        {
            return bag.Range(new Product { Name = "lowerRange", Price = min}, true, new Product { Name = "upperRange", Price = max}, true)
                .Take(22)
                .ToList();
        }
    }
}
