namespace Starks.Bank
{
    public class Account
    {
        internal Account(string id, Customer customer, decimal balance)
        {
            Id = id;
            Customer = customer;
            Balance = balance;
        }
        public string Id { get; }

        public Customer Customer { get; }

        public decimal Balance { get; private set; }

        internal void DepositMoney(decimal depositAmount)
        {
            Balance += depositAmount;
        }

        internal void WithdrawMoney(decimal withdrawAmount)
        {
            Balance -= withdrawAmount;
        }
    }
}
