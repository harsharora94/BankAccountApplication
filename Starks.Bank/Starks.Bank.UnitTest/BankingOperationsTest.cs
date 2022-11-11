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
        public void Given_Customer_Name_When_Create_Account_Then_Return_Unique_AccountId()
        {
            // Given
            BankingOperations bankingOperations = new BankingOperations();

            //When
        }

        [TestMethod]
        public void Get_Account_Details_By_Valid_CustomerId()
        {
            // Arrange
            var customerId = "";
            var bankingOps = new BankingOperations();

            // Act 
            var accountDetails = bankingOps.GetAccountDetails(customerId);

            // Arrange
            Assert.AreEqual(customerId, accountDetails.Id);
        }
    }
}