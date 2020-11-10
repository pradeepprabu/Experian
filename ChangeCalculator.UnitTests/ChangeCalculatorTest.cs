using System;
using System.Collections.Generic;
using Xunit;

namespace ChangeCalculator.UnitTests
{
    public class ChangeCalculatorTest
    {
        [Theory]
        [MemberData(nameof(GetData))]
        public void CalculateChange_ValidData_ReturnsCorrectly(double amount, double productPrice, Dictionary<double, int> expectedResult)
        {
            // Arrange

            // Act
            var calculator = new ConsoleApp.ChangeCalculator();
            calculator.CalculateChange(amount, productPrice);

            // Assert
            var dict = calculator.GetChange();
            Assert.NotNull(dict);
            Assert.Equal(expectedResult.Count, dict.Count);

            foreach (var item in dict)
            {
                Assert.Contains(item, expectedResult);
            }
        }

        [Fact]
        public void CalculateChange_InValidData_ThrowsException()
        {
            // Arrange
            const double amount = 10;
            const double productPrice = 20;

            // Act
            var calculator = new ConsoleApp.ChangeCalculator();

            // Assert
            Assert.Throws<ArgumentException>(() => calculator.CalculateChange(amount, productPrice));
        }

        public static IEnumerable<object[]> GetData()
        {
            var allData = new List<object[]>
        {
            new object[] { 20, 5.5, new Dictionary<double, int> { { 10, 1}, { 2, 2 }, { 0.5, 1 } } },
            new object[] { 50, 17.75, new Dictionary<double, int> { { 20, 1}, { 10, 1 }, { 2, 1 }, { 0.2, 1 }, { .05, 1 } } },
            new object[] { 10, 2.60, new Dictionary<double, int> { { 5, 1}, { 2, 1 }, { .2, 2 } } },
            new object[] { 500, 227.27, new Dictionary<double, int> { { 100, 2}, { 50, 1 }, { 20, 1 }, { 2, 1 }, { .5, 1 }, { .2, 1 }, { .02, 1 }, { .01, 1 } } },
            new object[] { 20, 20, new Dictionary<double, int>() },
        };

            return allData;
        }
    }
}
