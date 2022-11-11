namespace Starks.Bank
{
    public class Account
    {
        internal Account(string id, Customer customer)
        {
            Id = id;
            Customer = customer;
        }
        public string Id { get; }

        public Customer Customer { get; }

        public decimal Balance { get; }
    }
}
