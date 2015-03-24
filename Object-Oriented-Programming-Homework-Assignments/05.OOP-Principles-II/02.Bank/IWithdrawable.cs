namespace _02.Bank
{
    public interface IWithdrawable : IDepositable
    {
        void Withdraw(decimal amount);
    }
}
