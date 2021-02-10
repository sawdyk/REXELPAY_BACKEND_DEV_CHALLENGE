using REXELPAY.Helpers.Utilities;
using REXELPAY.Repository.Checkers.Repository.Interface;
using System;
using Xunit;
using Moq;
using REXELPAY.Repository.Checkers.Repository;
using Microsoft.Extensions.Logging;
using REXELPAY.Repository.Multiples.Repository;
using REXELPAY.Models.RequestModels;
using REXELPAY.Models.ResponseModels;
using System.Threading.Tasks;
using REXELPAY.Controllers;
using REXELPAY.Repository.Multiples.Repository.Interface;
using Microsoft.AspNetCore.Mvc;

namespace REXELPAY.Tests.ControllerTests
{
    public class MultiplesControllerTest
    {
        [Fact]
        public void ReturnsOkRequest_ValidModel_ValidResponse_MultipleController()
        {
            //Arrange  
            MultipleRequestModel requestModel = new MultipleRequestModel
            {
                Number = 25
            };

            //Act
            Mock<IMultiplesRepository> mockObjectChecker = new Mock<IMultiplesRepository>();

            MultiplesController controller = new MultiplesController(mockObjectChecker.Object);
            var actualResult = controller.checkForMultiplesOfThreeAndFiveAsync(requestModel);

            //Assert  
            Assert.NotNull(actualResult);
            Assert.IsType<Task<IActionResult>>(actualResult);
            Assert.True(actualResult.IsCompletedSuccessfully);
        }

        [Fact]
        public async Task ReturnsOkRequest_ValidModel_MultipleController()
        {
            //Arrange  
            MultipleRequestModel requestModel = new MultipleRequestModel
            {
                Number = 20
            };
            //Arrange and Act
            Mock<IMultiplesRepository> mockObjectChecker = new Mock<IMultiplesRepository>();
            MultiplesController controller = new MultiplesController(mockObjectChecker.Object);

            // Act
            var result = await controller.checkForMultiplesOfThreeAndFiveAsync(requestModel);

            // Assert
            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public async Task ReturnsBadRequest_InvalidModel_MultipleController()
        {
            //Arrange and Act
            Mock<IMultiplesRepository> mockObjectChecker = new Mock<IMultiplesRepository>();
            MultiplesController controller = new MultiplesController(mockObjectChecker.Object);
            controller.ModelState.AddModelError("error", "Invalid");

            // Act
            var result = await controller.checkForMultiplesOfThreeAndFiveAsync(null);

            // Assert
            Assert.IsType<BadRequestResult>(result);
        }
    }
}
