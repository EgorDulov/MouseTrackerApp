using Microsoft.AspNetCore.Mvc;
using Moq;
using MouseTracker.Data.Repositories;
using MouseTracker.Web.Controllers;
using MouseTracker.Web.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace MouseTracker.Tests
{
    public class MouseControllerTests
    {
        [Fact]
        public async Task SendMousePositions_SavesData_ReturnsOk()
        {
            // Arrange
            var mockRepo = new Mock<IMouseMovementRepository>();
            mockRepo.Setup(r => r.SaveMouseMovementsAsync(It.IsAny<IEnumerable<MouseTracker.Data.Models.MouseMovement>>()))
                .Returns(Task.CompletedTask);
            var controller = new MouseController(mockRepo.Object);
            var positions = new List<MousePositionDTO>
            {
                new MousePositionDTO { X = 10, Y = 20, T = DateTime.UtcNow }
            };

            // Act
            var result = await controller.SendMousePositions(positions);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnValue = Assert.IsType<SuccessResponse>(okResult.Value);
            Assert.Equal("Данные успешно сохранены", returnValue.Message);
            mockRepo.Verify(r => r.SaveMouseMovementsAsync(It.IsAny<IEnumerable<MouseTracker.Data.Models.MouseMovement>>()), Times.Once());
        }
    }
}