namespace Starks.Bank
{
    public interface IBankingOperations
    {
        Account GetAccountDetails(string accountId);
        string CreateAccount(string name, decimal balance);
        void DeleteAccount(string accountId);

        void Deposit(string accountId, decimal i);
    }
}
