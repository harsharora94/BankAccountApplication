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
            var account = accounts.FirstOrDefault(a => a.Id.Equals(customerId));
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
            Account account = new Account(GetAccountId(), new Customer() { Name = name });
            
            accounts.Add(account);
            return account.Id;
        }

        private string GetAccountId()
        {
           return  accountRunningId.ToString("00000000");
        }
    }
}