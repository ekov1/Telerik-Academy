using System;

namespace Facade
{
    public class Program
    {
        public static void Main()
        {
            var chef = new PastryChef();
            var assistant = new AssistantChef();
            var pastryChef = new PastryChefFacade(chef, assistant);

            Console.WriteLine("~~~ Preparing the cake ~~~");
            pastryChef.PrepareCake();

            Console.WriteLine("\n~~~ Baking the cake ~~~");
            pastryChef.BakeCake();

            Console.WriteLine("\n~~~ Serving the cake ~~~");
            pastryChef.ServeCake();

            Console.WriteLine("\n~~~ Cleaning up ~~~");
            pastryChef.CleanUp();

            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("\nDisclaimer: This is not how you prepare a conventional cake, so do not follow these steps. Peace out!");
            Console.ResetColor();
        }
    }
}
