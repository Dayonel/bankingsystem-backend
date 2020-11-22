using BankingSystem.Core.DTO;
using BankingSystem.Core.DTO.Base;
using BankingSystem.Core.Interfaces.Services;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BankingSystem.UnitTests.Service
{
    public class AccountServiceTests
    {
        private Mock<IAccountService> accountServiceMoq;

        [SetUp]
        public void Setup()
        {
            accountServiceMoq = new Mock<IAccountService>();
        }


        [Test]
        public async Task Get_Accounts_By_Client_Id_Many_Exist()
        {
            // Arrange
            var clientId = 1;
            accountServiceMoq.Setup(s => s.GetByClientId(clientId)).ReturnsAsync(() => new List<AccountDTO> { new AccountDTO(), new AccountDTO() });

            // Act
            var accounts = await accountServiceMoq.Object.GetByClientId(clientId);

            // Assert
            Assert.AreEqual(2, accounts.Count);
        }

        [Test]
        public async Task Get_Accounts_By_Client_Id_Empty()
        {
            // Arrange
            var clientId = 2;
            accountServiceMoq.Setup(s => s.GetByClientId(clientId)).ReturnsAsync(() => new List<AccountDTO>());

            // Act
            var accounts = await accountServiceMoq.Object.GetByClientId(clientId);

            // Assert
            Assert.IsEmpty(accounts);
        }

        [Test]
        public async Task Deposit_Success()
        {
            // Arrange
            var accountId = 1;
            var amount = 20f;
            accountServiceMoq.Setup(s => s.Deposit(accountId, amount)).ReturnsAsync(() => new BaseDTO<bool>() { Data = true });

            // Act
            var deposit = await accountServiceMoq.Object.Deposit(accountId, amount);

            // Assert
            Assert.IsTrue(deposit.Data);
        }

        [Test]
        public async Task Deposit_No_Success()
        {
            // Arrange
            var accountId = 2;
            var amount = 10f;
            accountServiceMoq.Setup(s => s.Deposit(accountId, amount)).ReturnsAsync(() => new BaseDTO<bool>());

            // Act
            var deposit = await accountServiceMoq.Object.Deposit(accountId, amount);

            // Assert
            Assert.IsFalse(deposit.Data);
        }

        [Test]
        public async Task Withdraw_Success()
        {
            // Arrange
            var accountId = 2;
            var amount = 10f;
            accountServiceMoq.Setup(s => s.Withdraw(accountId, amount)).ReturnsAsync(() => new BaseDTO<bool>() { Data = true });

            // Act
            var deposit = await accountServiceMoq.Object.Withdraw(accountId, amount);

            // Assert
            Assert.IsTrue(deposit.Data);
        }

        [Test]
        public async Task Withdraw_No_Success()
        {
            // Arrange
            var accountId = 3;
            var amount = 5f;
            accountServiceMoq.Setup(s => s.Withdraw(accountId, amount)).ReturnsAsync(() => new BaseDTO<bool>() { ErrorMessage = "Insufficient funds." });

            // Act
            var deposit = await accountServiceMoq.Object.Withdraw(accountId, amount);

            // Assert
            Assert.IsFalse(deposit.Success);
        }
    }
}
