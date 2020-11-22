using BankingSystem.Core.Entity;
using BankingSystem.Core.Entity.Enum;
using BankingSystem.Core.Interfaces.Repository;
using Moq;
using NUnit.Framework;
using System.Threading.Tasks;

namespace BankingSystem.UnitTests.Repository
{
    public class AccountTypeRepositoryTests
    {
        [Test]
        public async Task Get_AccountType_By_Id()
        {
            // Arrange
            var id = 1;
            var type = AccountTypeEnum.DepositAccount;
            Mock<IAccountTypeRepository> accountTypeMock = new Mock<IAccountTypeRepository>();
            accountTypeMock.Setup(s => s.GetById(id)).ReturnsAsync(() => new AccountType { Type = type });

            // Act
            var accountType = await accountTypeMock.Object.GetById(id);

            // Assert
            Assert.That(accountType.Type == type);
        }
    }
}
