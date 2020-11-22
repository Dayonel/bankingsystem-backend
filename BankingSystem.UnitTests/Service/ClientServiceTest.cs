using BankingSystem.Core.DTO;
using BankingSystem.Core.DTO.Base;
using BankingSystem.Core.Interfaces.Services;
using Moq;
using NUnit.Framework;
using System;
using System.Threading.Tasks;

namespace BankingSystem.UnitTests.Service
{
    public class ClientServiceTest
    {
        [Test]
        public async Task Get_Client_By_Id_Exists()
        {
            // Arrange
            var id = 1;
            var clientName = Guid.NewGuid().ToString();
            Mock<IClientService> clientServiceMoq = new Mock<IClientService>();
            clientServiceMoq.Setup(s => s.GetById(id)).ReturnsAsync(() => new BaseDTO<ClientDTO> { Data = new ClientDTO { Name = clientName } });

            // Act
            var client = await clientServiceMoq.Object.GetById(id);

            // Assert
            Assert.IsNotNull(client.Data);
            Assert.That(client.Data.Name == clientName);
        }

        [Test]
        public async Task Get_Client_By_Id_Doesnt_Exists()
        {
            // Arrange
            var id = 2;
            Mock<IClientService> clientServiceMoq = new Mock<IClientService>();
            clientServiceMoq.Setup(s => s.GetById(id)).ReturnsAsync(() => new BaseDTO<ClientDTO>());

            // Act
            var client = await clientServiceMoq.Object.GetById(id);

            // Assert
            Assert.IsNull(client.Data);
        }
    }
}
