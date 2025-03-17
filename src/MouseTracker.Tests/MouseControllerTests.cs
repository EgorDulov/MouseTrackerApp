using Microsoft.AspNetCore.Mvc;
using Moq;
using MouseTracker.Web.Controllers;
using MouseTracker.Application.UseCases;
using MouseTracker.Application.DTOs;
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
            var mockUseCase = new Mock<SaveMouseMovementsUseCase>(MockBehavior.Strict);
            mockUseCase.Setup(u => u.ExecuteAsync(It.IsAny<IEnumerable<MousePositionDTO>>()))
                .Returns(Task.CompletedTask);
            var controller = new MouseController(mockUseCase.Object);
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
            mockUseCase.Verify(u => u.ExecuteAsync(It.IsAny<IEnumerable<MousePositionDTO>>()), Times.Once());
        }
    }
}