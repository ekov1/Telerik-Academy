namespace Code_First_Cars_ConsoleClient
{
    using Code_First_Cars.Data;

    public class Program
    {
        static void Main()
        {
            var data = new CarsDbContext();

            JsonImporter.Import(data);
        }
    }
}
