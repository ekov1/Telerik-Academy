namespace CSharpExam_Money
{
    using System;

    public class Money
    {
        private const int SheetsPerRealm = 400;

        public static void Main()
        {
            int students = int.Parse(Console.ReadLine());
            int sheets = int.Parse(Console.ReadLine());
            double realmCost = double.Parse(Console.ReadLine());

            double totalPaper = students * sheets;
            double totalRealms = totalPaper / SheetsPerRealm;
            double totalCost = totalRealms * realmCost;

            Console.WriteLine("{0:F3}", totalCost);
        }
    }
}