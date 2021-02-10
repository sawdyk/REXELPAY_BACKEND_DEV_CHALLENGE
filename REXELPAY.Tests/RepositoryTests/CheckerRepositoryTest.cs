using REXELPAY.Helpers.Utilities;
using REXELPAY.Repository.Checkers.Repository.Interface;
using System;
using Xunit;
using Moq;
using REXELPAY.Repository.Checkers.Repository;
using Microsoft.Extensions.Logging;

namespace REXELPAY.Tests
{
    public class CheckerRepositoryTest
    {

        [Fact]
        public void Test1()
        {
            //Arrange  
            int number = 1;
            var expectedValue = EnumUtility.MultipleCodes.Not_A_Multiple_Of_Three_Or_Five;

            //Act
            Mock<ILogger<CheckerRepository>> mckObj = new Mock<ILogger<CheckerRepository>>();
            CheckerRepository chhh = new CheckerRepository(mckObj.Object);
            var actualResult = chhh.checkNumberAsync(number);

            //Assert  
            Assert.Equal(expectedValue, actualResult);
        }
    }
}
