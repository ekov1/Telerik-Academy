using System;

namespace _02.Bank
{
    class DepositAccount : Account, IWithdrawable
    {
        public DepositAccount(CustomerType customer, decimal balance, decimal interestRate)
            : base(customer, balance, interestRate)
        {
        }


        public override decimal CalcInterest(int months)
        {
            if (this.Balance >= 1000 || this.Balance < 0)
            {
                return (decimal) this.InterestRate * this.Balance / months;
            }
            else
            {
                return 0;
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

        public void Withdraw(decimal amount)
        {
            if (amount >= this.Balance)
            {
                this.Balance -= amount;
            }
        }
    }
}
