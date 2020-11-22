using BankingSystem.Core.Entity;
using BankingSystem.Core.Interfaces.Repository;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankingSystem.UnitTests.Repository
{
    public class AccountRepositoryTests
    {
        private Mock<IAccountRepository> accountRepoMock;

        [SetUp]
        public void Setup()
        {
            accountRepoMock = new Mock<IAccountRepository>();
        }

        [Test]
        public async Task Get_Account_By_Id()
        {
            // Arrange
            var id = 1;
            var balance = 2.65f;
            accountRepoMock.Setup(s => s.GetById(id)).ReturnsAsync(() => new Account { Balance = balance });

            // Act
            var account = await accountRepoMock.Object.GetById(id);

            // Assert
            Assert.That(account.Balance == balance);
        }

        [Test]
        public async Task Get_Account_By_ClientId()
        {
            // Arrange
            var clientId = 1;
            var accountNumber = 4;
            accountRepoMock.Setup(s => s.GetByClientId(clientId)).ReturnsAsync(() => 
                new List<Account> { new Account { AccountNumber = accountNumber } });

            // Act
            var accounts = await accountRepoMock.Object.GetByClientId(clientId);

            // Assert
            Assert.That(accounts.Count() == 1);
            Assert.That(accounts.First().AccountNumber == accountNumber);
        }
    }
}
