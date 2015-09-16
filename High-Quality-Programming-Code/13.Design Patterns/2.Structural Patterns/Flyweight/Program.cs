namespace Flyweight
{
    using System;

    public class Program
    {
        public static void Main()
        {
            var chitins = new string[]{"Green", "Red", "Blue", "Ashen", "Pitch-Black", "Pale-Green"};
            var numberOfInfestations = 15;
            var rng = new Random();

            var locustFactory = new LocustFactory();

            for (int i = 0; i < numberOfInfestations; i++)
            {
                var locust = locustFactory.GetLocust(chitins[rng.Next()%chitins.Length]);
                SetColor(locust);
                locust.Infest();
            }

            Console.ResetColor();

            Console.WriteLine("\nNumber of created objects after {0} infestations - {1}!", numberOfInfestations, locustFactory.NumberOfEntries());
        }

        private static void SetColor(ILocust locust)
        {
            switch (locust.ChitinColor)
            {
                case "Red":
                    {
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        break;
                    }
                case "Green":
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        break;
                    }
                case "Blue":
                    {
                        Console.ForegroundColor = ConsoleColor.Blue;
                        break;
                    }
                case "Pale-Green":
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        break;
                    }
                case "Ashen":
                    {
                        Console.ForegroundColor = ConsoleColor.DarkGray;
                        break;
                    }
                default:
                    Console.ResetColor();
                    break;
            }
        }
    }
}
