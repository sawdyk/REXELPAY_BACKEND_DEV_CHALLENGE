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
        public void TestMultiplesOfThreeOrFive()
        {
            //Arrange  
            int number = 15;
            var expectedValue = EnumUtility.MultipleCodes.Multiple_Of_Three_And_Five;

            //Act
            Mock<ILogger<CheckerRepository>> mckObj = new Mock<ILogger<CheckerRepository>>();
            CheckerRepository chhh = new CheckerRepository(mckObj.Object);
            var actualResult = chhh.checkNumberAsync(number);

            //Assert  
            Assert.Equal(expectedValue, actualResult);
        }

        [Fact]
        public void TestMultiplesOfFive()
        {
            //Arrange  
            int number = 25;
            var expectedValue = EnumUtility.MultipleCodes.Multiple_Of_Five;

            //Act
            Mock<ILogger<CheckerRepository>> mckObj = new Mock<ILogger<CheckerRepository>>();
            CheckerRepository chhh = new CheckerRepository(mckObj.Object);
            var actualResult = chhh.checkNumberAsync(number);

            //Assert  
            Assert.Equal(expectedValue, actualResult);
        }

        [Fact]
        public void TestMultiplesOfThree()
        {
            //Arrange  
            int number = 39;
            var expectedValue = EnumUtility.MultipleCodes.Multiple_Of_Three;

            //Act
            Mock<ILogger<CheckerRepository>> mckObj = new Mock<ILogger<CheckerRepository>>();
            CheckerRepository chhh = new CheckerRepository(mckObj.Object);
            var actualResult = chhh.checkNumberAsync(number);

            //Assert  
            Assert.Equal(expectedValue, actualResult);
        }

        [Fact]
        public void TestNotMultiplesOfThreeOrFive()
        {
            //Arrange  
            int number = 11;
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
