namespace Starks.Bank
{
    public class BankingOperations
    {
        int accountRunningId = 1;
        List<Account> accounts;
        public BankingOperations()
        {
            accounts = new List<Account>();
        }
        public Account GetAccountDetails(string customerId)
        {
            throw new InvalidDataException();
        }
        public string CreateAccount(string name, decimal balance)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentNullException("name");
            };
            Account account = new Account {
                Id = GetAccountId(),
                Customer = new Customer { Name = name }
            
            };
            return account.Id;
        }

        private string GetAccountId()
        {
           return  accountRunningId.ToString("00000000");
        }
    }
}