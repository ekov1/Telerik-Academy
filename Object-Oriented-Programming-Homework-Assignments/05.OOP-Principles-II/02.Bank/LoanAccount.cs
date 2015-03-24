using System;

namespace _02.Bank
{
    public class LoanAccount : Account, IDepositable
    {
        public LoanAccount(CustomerType customer, decimal balance, decimal interestRate)
            : base(customer, balance, interestRate)
        {
        }

        public override decimal CalcInterest(int months)
        {
            if (this.Customer == CustomerType.Individual)
            {
                months = Math.Max(0, months - 3);
                return (decimal)this.InterestRate/100 * this.Balance / (months);
            }
            else 
            {
                months = Math.Max(0, months - 2);
                return (decimal)this.InterestRate/100 * this.Balance / (months);
            }
        }

        public void Deposit(decimal amount)
        {
            if (amount > 0)
            {
                this.Balance += amount;
            }
            else
            {
                throw new ArgumentOutOfRangeException("You cheap bastard");
            }
        }
    }
}
