using BankingSystem.Core.Entity;
using BankingSystem.Core.Interfaces.Repository;
using Moq;
using NUnit.Framework;
using System.Threading.Tasks;

namespace BankingSystem.UnitTests.Repository
{
    public class ClientRepositoryUnitTests
    {
        [Test]
        public async Task Get_Client_By_Id()
        {
            // Arrange
            var id = 1;
            var clientName = "Test works.";
            Mock<IClientRepository> clientMockRepo = new Mock<IClientRepository>();
            clientMockRepo.Setup(s => s.GetById(id)).ReturnsAsync(() => new Client { Name = clientName });

            // Act
            var client = await clientMockRepo.Object.GetById(id);

            // Assert
            Assert.That(client.Name == clientName);
        }
    }
}
