namespace Starks.Bank
{
    public class BankingOperations : IBankingOperations
    {
        readonly int accountRunningId = 1;
        readonly List<Account> accounts;
        public BankingOperations()
        {
            accounts = new List<Account>();
        }
        public Account GetAccountDetails(string accountId)
        {
            var account = accounts.FirstOrDefault(a => a.Id.Equals(accountId));
            if (account == null)
            {
                throw new InvalidDataException();
            }

            return account;
        }
        public string CreateAccount(string name, decimal balance)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentNullException("name");
            };
            Account account = new Account(GetAccountId(), new Customer() { Name = name }, balance);
            
            accounts.Add(account);
            return account.Id;
        }

        private string GetAccountId()
        {
           return  accountRunningId.ToString("00000000");
        }

        public void DeleteAccount(string accountId)
        {
            
        }
    }
}