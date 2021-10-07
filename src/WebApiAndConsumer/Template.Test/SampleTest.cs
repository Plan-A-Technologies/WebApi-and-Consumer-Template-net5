using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Template.Bll.Dto;
using Template.Bll.Services;
using Template.Dal;
using Template.Dal.Entities;

namespace Template.Test
{
    [TestClass]
    public class SampleTest
    {
        private Mock<AppDbContext> _contextMock;
        private Mock<DbSet<Player>> _mockDbSet;
        private Mock<IMapper> _mapperMock;

        [TestInitialize]
        public void Initialize()
        {
            _contextMock = new Mock<AppDbContext>();
            _mockDbSet = new Mock<DbSet<Player>>();
            _mapperMock = new Mock<IMapper>();

        }

        [TestCleanup]
        public void Cleanup()
        {
            _contextMock = null;
            _mapperMock = null;
        }

        [TestMethod]
        [TestCategory("Build [pos]")]
        public async Task Service_SampleTest_Positive()
        {
            // Arrange
            var playerDto = new PlayerDto
            {
                FirstName = "John",
                LastName = "Doe"
            };

            var player = new Player
            {
                FirstName = "John",
                LastName = "Doe"
            };

            _mapperMock
                .Setup(f => f.Map<Player>(It.IsAny<PlayerDto>()))
                .Returns(player);

            _mapperMock
                .Setup(f => f.Map<PlayerDto>(It.IsAny<Player>()))
                .Returns(playerDto);

            _contextMock
                .Setup(f => f.Players)
                .Returns(_mockDbSet.Object);

            var playerService = new PlayerService(_contextMock.Object, _mapperMock.Object);

            // Act
            var createdPlayer = await playerService.CreatePlayer(playerDto);

            // Assert
            Assert.IsNotNull(createdPlayer);
            Assert.AreEqual(createdPlayer.FirstName, playerDto.FirstName);
        }
    }
}
