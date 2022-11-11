
namespace Starks.Bank.UnitTest
{
    [TestClass]
    public class BankingOperationsTest
    {
        [TestMethod]
        public void Get_Account_Details_By_Invalid_CustomerId_Throws_Exception()
        {
            // Arrange
            var customerId = "";
            var bankingOps = new BankingOperations();

            // Act and Assert
            Assert.ThrowsException<InvalidDataException>(() => bankingOps.GetAccountDetails(customerId));
        }

        [TestMethod]
        public void Given_Empty_customerName_SHould_throwException()
        {
            // Given
            BankingOperations bankingOperations = new BankingOperations();

            //When
            Assert.ThrowsException<ArgumentNullException>(() => bankingOperations.CreateAccount(string.Empty, 0));
            
        }

        [TestMethod]
        public void Given_CustomerName_Should_CreateAccount()
        {
            // Given
            BankingOperations bankingOperations = new BankingOperations();
            var accountId = bankingOperations.CreateAccount("CustName", 0);

            Assert.IsNotNull(accountId);
            Assert.AreEqual(8,accountId.Length);

        }

        [TestMethod]
        public void Get_Account_Details_By_Valid_CustomerId()
        {
            // Arrange
            var customerId = "CustName";
            var bankingOps = new BankingOperations();

            // Act 
            var custId =bankingOps.CreateAccount(customerId, 0);
            var accountDetails = bankingOps.GetAccountDetails(custId);

            // Arrange
            Assert.AreEqual(8, accountDetails.Id.Length);
            Assert.AreEqual(0, accountDetails.Balance);
        }

        [TestMethod]
        public void Should_Create_account_with_OpeningBalance()
        {
            // Given
            BankingOperations bankingOperations = new BankingOperations();
            var accountId = bankingOperations.CreateAccount("CustName", 100);
            var accounDetails = bankingOperations.GetAccountDetails(accountId);

            Assert.AreEqual(100M, accounDetails.Balance);
        }
    }
}