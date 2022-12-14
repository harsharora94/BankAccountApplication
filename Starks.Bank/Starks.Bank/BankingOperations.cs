namespace Starks.Bank
{
    public class BankingOperations : IBankingOperations
    {
        private int InitialAccountRunningId = 0;
        readonly List<Account> myAccounts;

        public BankingOperations()
        {
            myAccounts = new List<Account>();
        }

        public Account GetAccountDetails(string accountId)
        {
            var account = myAccounts.FirstOrDefault(a => a.Id.Equals(accountId));
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
            }

            if (balance < 0)
            {
                throw new InvalidOperationException();
            }

            ;
            Account account = new Account(CreateUniqueAccountId(), new Customer() { Name = name }, balance);

            myAccounts.Add(account);
            return account.Id;
        }

        private string CreateUniqueAccountId()
        {
            InitialAccountRunningId++;
            return InitialAccountRunningId.ToString("00000000");
        }

        public void DeleteAccount(string accountId)
        {
            myAccounts.Remove(myAccounts.First(a => a.Id.Equals(accountId)));
        }

        public decimal Withdraw(string accountId, decimal amount)
        {
            if (string.IsNullOrEmpty(accountId))
                throw new ArgumentNullException(nameof (accountId));

            var account =  myAccounts.FirstOrDefault(a => a.Id.Equals(accountId));

            if (account == null || amount <= 0)
                throw new InvalidOperationException();

            if(account.Balance < amount)
                throw new InvalidOperationException();

            account.WithdrawMoney(amount);

            return amount;
        }

        public void Deposit(string accountId, decimal depositAmount)
        {
            if (depositAmount < 0 || accountId == null)
            {
                throw new InvalidOperationException();
            }

            var account = myAccounts.First(a => a.Id.Equals(accountId));
            account.DepositMoney(depositAmount);
        }
    }
}