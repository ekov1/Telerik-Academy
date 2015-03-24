namespace _02.Bank
{
    public abstract class Account
    {
        private CustomerType customer;
        private decimal balance;
        private decimal interestRate;

        public Account(CustomerType customer, decimal balance, decimal interestRate)
        {
            this.Customer = customer;
            this.Balance = balance;
            this.InterestRate = interestRate;
        }

        public CustomerType Customer
        {
            get { return customer; }
            private set { customer = value; }
        }

        public decimal Balance
        {
            get { return balance; }
            set { balance = value; }
        }

        public decimal InterestRate
        {
            get { return interestRate; }
            set { interestRate = value; }
        }

        public abstract decimal CalcInterest(int months);
    }
}
