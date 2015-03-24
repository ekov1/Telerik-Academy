using System;

namespace _02.Bank
{
    class MortgageAccount: Account, IDepositable
    {
        public MortgageAccount(CustomerType customer, decimal balance, decimal interestRate)
            : base(customer, balance, interestRate)
        {
        }

        public override decimal CalcInterest(int months)
        {
            if (this.Customer == CustomerType.Individual)
            {
                if (months >= 12)
                {
                    return (decimal) this.InterestRate/100*0.5m*this.Balance/12 + this.InterestRate*this.Balance/(months - 12);
                }
                else
                {
                    return (decimal) this.InterestRate/100*0.5m*this.Balance/months;
                }
            }
            else 
            {
                if (months > 6)
                {
                    return (decimal)this.InterestRate/100 * 0.5m * this.Balance / (months-6);
                }
                else
                {
                    return 0;
                }
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
