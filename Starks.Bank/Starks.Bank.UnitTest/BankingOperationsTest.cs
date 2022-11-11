
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
            // Arrange
            BankingOperations bankingOperations = new BankingOperations();

            // Act and Assert
            Assert.ThrowsException<ArgumentNullException>(() => bankingOperations.CreateAccount(string.Empty, 0));
            
        }

        [TestMethod]
        public void Given_CustomerName_Should_CreateAccount()
        {
            // Arrange
            BankingOperations bankingOperations = new BankingOperations();

            // Act
            var accountId = bankingOperations.CreateAccount("CustName", 0);

            // Assert
            Assert.IsNotNull(accountId);
            Assert.AreEqual(8,accountId.Length);

        }

        [TestMethod]
        public void Should_Not_Create_Duplicate_Account_Numbers()
        {
            // Arrange
            BankingOperations bankingOperations = new BankingOperations();

            // Act
            var accountId1 = bankingOperations.CreateAccount("CustName", 0);
            var accountId2 = bankingOperations.CreateAccount("CustName", 0);

            // Assert
            Assert.AreNotEqual(accountId1, accountId2);
        }

        [TestMethod]
        public void Should_Not_Create_account_With_Negative_Balance()
        {
            // Arrange
            BankingOperations bankingOperations = new BankingOperations();

            // Act and Assert
            Assert.ThrowsException<InvalidOperationException>(()=> bankingOperations.CreateAccount("CustName", -10));
        }

        [TestMethod]
        public void Get_Account_Details_By_Valid_CustomerId()
        {
            // Arrange
            var customerName = "CustName";
            var bankingOps = new BankingOperations();

            // Act 
            var custId =bankingOps.CreateAccount(customerName, 0);
            var accountDetails = bankingOps.GetAccountDetails(custId);

            // Assert
            Assert.AreEqual(8, accountDetails.Id.Length);
            Assert.AreEqual(0, accountDetails.Balance);
            Assert.AreEqual(customerName, accountDetails.Customer.Name);
        }

        [TestMethod]
        public void Delete_Account_When_AccountIsValid()
        {
            // Arrange
            var accountId = "CustName";
            var bankingOps = new BankingOperations();

            // Act 
            var custId = bankingOps.CreateAccount(accountId, 0);
            bankingOps.DeleteAccount(custId);

            // Arrange
            Assert.ThrowsException<InvalidDataException>(() => bankingOps.GetAccountDetails(custId));
        }

        [TestMethod]
        public void Delete_Account_When_AccountIsNot_Existing_ThrowsException()
        {
            // Arrange
            var bankingOps = new BankingOperations();

            // Act and Assert
            Assert.ThrowsException<InvalidOperationException>(() => bankingOps.DeleteAccount("accountId"));
        }

        [TestMethod]
        public void Should_Create_Account_with_OpeningBalance()
        {
            // Arrange
            BankingOperations bankingOperations = new BankingOperations();

            // Act
            var accountId = bankingOperations.CreateAccount("CustName", 100);

            // Assert
            var accounDetails = bankingOperations.GetAccountDetails(accountId);
            Assert.AreEqual(100M, accounDetails.Balance);
        }

        [TestMethod]
        public void Deposit_WhenAccountIsValid_AmountShould_BeAddedToBalance()
        {
            // Arrange
            BankingOperations bankingOperations = new BankingOperations();
            var accountId = bankingOperations.CreateAccount("CustName", 100);
            
            // Act
            bankingOperations.Deposit(accountId, 1000);

            // Assert
            var accounDetails = bankingOperations.GetAccountDetails(accountId);
            Assert.AreEqual(1100, accounDetails.Balance);
        }

        [TestMethod]
        public void Deposit_WhenAccountIsInValid_ThrowsException()
        {
            // Arrange
            BankingOperations bankingOperations = new BankingOperations();
            var accountId = bankingOperations.CreateAccount("CustName", 100);

            // Act and Assert
            Assert.ThrowsException<InvalidOperationException>(()=> bankingOperations.Deposit("invalid", 1000));
        }

        [TestMethod]
        public void Deposit_WhenAccountIdIsNull_ThrowsException()
        {
            // Arrange
            BankingOperations bankingOperations = new BankingOperations();
            var accountId = bankingOperations.CreateAccount("CustName", 100);

            // Act and Assert
            Assert.ThrowsException<InvalidOperationException>(() => bankingOperations.Deposit(null, 1000));
        }

        [TestMethod]
        public void Deposit_WhenAccountIsValidAndAmountIsNegative_ThrowsException()
        {
            // Arrange
            BankingOperations bankingOperations = new BankingOperations();
            var accountId = bankingOperations.CreateAccount("CustName", 100);

            // Act and Assert
            Assert.ThrowsException<InvalidOperationException>(() => bankingOperations.Deposit(accountId, -1000));
        }

        [TestMethod]
        public void Should_Throw_Invalid_Exception_When_Account_Is_Invalid()
        {
            // Given
            BankingOperations bankingOperations = new BankingOperations();
            // Then  & //Assert
            Assert.ThrowsException<InvalidOperationException>(() => bankingOperations.Withdraw("Invalid Account Id", 0));
        }

        [TestMethod]
        public void Should_Throw_Argument_Null_Exception_When_AccountId_Is_Empty()
        {
            // Given
            BankingOperations bankingOperations = new BankingOperations();
            // Then  & //Assert
            Assert.ThrowsException<ArgumentNullException>(() => bankingOperations.Withdraw(string.Empty, 0));
        }

        [TestMethod]
        public void Should_Throw_Invalid_Operation_Exception_When_Withdrawal_Amount_Is_Less_Than_One()
        {
            // Given
            BankingOperations bankingOperations = new BankingOperations();
            var accounId =  bankingOperations.CreateAccount("XYZ", 0);

            // Then 
            Assert.ThrowsException<InvalidOperationException>(() => bankingOperations.Withdraw(accounId, 0));
        }

        [TestMethod]
        public void Should_Throw_Invalid_Operation_Exception_When_Withdrawal_Amount_Is_More_Than_Balance()
        {
            // Given
            BankingOperations bankingOperations = new BankingOperations();
            var accounId = bankingOperations.CreateAccount("XYZ", 100);

            // Then 
            Assert.ThrowsException<InvalidOperationException>(() => bankingOperations.Withdraw(accounId, 120));
        }

        [TestMethod]
        public void Should_Withdraw_When_Withdrawal_Amount_Is_Not_More_Than_Current_Balance()
        {
            // Given
            BankingOperations bankingOperations = new BankingOperations();
            var accounId = bankingOperations.CreateAccount("XYZ", 100);

            var amount = bankingOperations.Withdraw(accounId, 80);

            var accountDetails = bankingOperations.GetAccountDetails(accounId);

            // Then 
            Assert.AreEqual(80, amount);
            Assert.AreEqual(20, accountDetails.Balance);
        }
    }
}