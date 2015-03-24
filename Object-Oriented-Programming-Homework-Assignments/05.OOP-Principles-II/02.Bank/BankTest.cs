using System;
using System.Collections.Generic;

namespace _02.Bank
{
    class BankTest
    {
        static void Main()
        {

            List<Account> bankAccounts = new List<Account>
            {
                new DepositAccount(CustomerType.Individual, 1222.21m, 2.4m),
                new MortgageAccount(CustomerType.Company, 25040m, 6.7m),
                new LoanAccount(CustomerType.Individual, 34200m, 9.2m)
            };

            foreach (var account in bankAccounts)
            {
                Console.WriteLine("Account holder: " + account.Customer);
                Console.WriteLine("Account type: " + account.GetType().ToString().TrimStart("_02.Bank".ToCharArray()));
                Console.WriteLine("Account balance:" + account.Balance);
                Console.WriteLine("Interest rate:" + account.InterestRate);
                Console.WriteLine("Interest (12 months): " + account.CalcInterest(12) + "/mo");
                Console.WriteLine();
            }
        }
    }
}
