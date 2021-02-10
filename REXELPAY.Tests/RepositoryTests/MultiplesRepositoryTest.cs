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
using Microsoft.AspNetCore.Mvc;

namespace REXELPAY.Tests.RepositoryTests
{
    public class MultiplesRepositoryTest
    {
        [Fact]
        public void TestFindMultiplesAsync()
        { 
            MultipleRequestModel requestModel = new MultipleRequestModel
            {
                Number = 15
            };

            //Act
            Mock<ILogger<MultiplesRepository>> mockObjectLog = new Mock<ILogger<MultiplesRepository>>();
            Mock<ICheckerRepository> mockObjectChecker = new Mock<ICheckerRepository>();

            MultiplesRepository repository = new MultiplesRepository(mockObjectChecker.Object, mockObjectLog.Object);
            var actualResult = repository.findMultiplesAsync(requestModel);

            //Assert  
            Assert.NotNull(actualResult);
            Assert.IsType<Task<GenericResponseModel>>(actualResult);
            Assert.True(actualResult.IsCompletedSuccessfully);
        }

    }
}
