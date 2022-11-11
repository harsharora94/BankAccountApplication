
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
    }
}