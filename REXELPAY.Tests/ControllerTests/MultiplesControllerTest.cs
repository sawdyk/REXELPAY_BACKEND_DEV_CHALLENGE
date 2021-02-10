﻿using REXELPAY.Helpers.Utilities;
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
        public void TestMultipleController()
        {
            //Arrange  
            MultipleRequestModel requestModel = new MultipleRequestModel
            {
                Number = 25
            };

            //Act
            Mock<ILogger<MultiplesController>> mockObjectLog = new Mock<ILogger<MultiplesController>>();
            Mock<IMultiplesRepository> mockObjectChecker = new Mock<IMultiplesRepository>();

            MultiplesController controller = new MultiplesController(mockObjectChecker.Object, mockObjectLog.Object);
            var actualResult = controller.findMultiplesAsync(requestModel);

            //Assert  
            Assert.NotNull(actualResult);
            Assert.IsType<Task<IActionResult>>(actualResult);
            Assert.True(actualResult.IsCompletedSuccessfully);
        }
    }
}