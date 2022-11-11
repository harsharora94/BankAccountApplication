namespace Starks.Bank.UnitTest
{
    [TestClass]
    public class BankingOperationsTest
    {
        [TestMethod]
        public void Get_Account_Details_By_CustomerId()
        {
            // Arrange
            var customerId = "";
            var bankingOps = new BankingOperations();

            // Act
            var accountDetails = bankingOps.GetAccountDetails(customerId);

            // Assert
            Assert.IsNotNull(accountDetails);
        }
    }
}