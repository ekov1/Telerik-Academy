namespace Extensions
{
    using System.IO;
    using System.Text;

    public class RandomDataGenerator
    {
        private const string ProductFormat = "{0} {1}";
        private const string ProductsPath = "../../Files/products.txt";

        private const string LoremPath = "../../Files/lorem.txt";

        static RandomDataGenerator()
        {
            if (!Directory.Exists("../../Files"))
            {
                Directory.CreateDirectory("../../Files");
            }
        }

        public static void GenerateProducts(uint products = 500000, string filePath = ProductsPath)
        {
            var sb = new StringBuilder();

            for (int i = 0; i < products; i++)
            {
                var product = RandomExtensions.GetString(4, 10);
                var price = RandomExtensions.GetDecimal(1, 999);

                sb.AppendLine(string.Format(ProductFormat, product, price));
            }

            var sw = File.CreateText(filePath);
            sw.Write(sb.ToString());
            sw.Dispose();
        }

        public static void GenerateLorem(string filePath = LoremPath)
        {
            var sb = new StringBuilder();

            var aVeryBigLorem = LoremNET.Lorem.Paragraph(25000, 35000, 190000, 200000);

            sb.Append(aVeryBigLorem);

            var sw = File.CreateText(filePath);
            sw.Write(sb.ToString());
            sw.Dispose();
        }
    }
}
