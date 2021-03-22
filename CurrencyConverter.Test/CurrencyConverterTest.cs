using CurrencyConverter.Database;
using CurrencyConverter.Services;
using Moq;
using Xunit;
using Xunit.Abstractions;

namespace CurrencyConverter.Test
{
    public class CurrencyConverterTest
    {

        private readonly ITestOutputHelper _testOutputHelper;

        public CurrencyConverterTest(ITestOutputHelper testOutputHelper)
        {
            _testOutputHelper = testOutputHelper;
        }

        [Theory]
        [InlineData(100)]
        [InlineData(220)]
        [InlineData(10000)]
        public void Convert_ToDollar_Test(decimal rubles)
        {
            var dbContext = new Mock<DbContext>();
            dbContext.Setup(x => x.GetCurse(It.IsAny<string>()))
                .Returns(74.6085m);

            var converter = new DollarConverter(dbContext.Object);
            var result = converter.FromRubles(rubles);

            _testOutputHelper.WriteLine($"result: {result}");
            Assert.True(result != 0m);
        }

        [Theory]
        [InlineData(100)]
        [InlineData(220)]
        [InlineData(10000)]
        public void Convert_ToEuro_Test(decimal rubles)
        {
            var dbContext = new Mock<DbContext>();
            dbContext.Setup(x => x.GetCurse(It.IsAny<string>()))
                .Returns(88.6573m);

            var converter = new DollarConverter(dbContext.Object);
            var result = converter.FromRubles(rubles);

            _testOutputHelper.WriteLine($"result: {result}");
            Assert.True(result != 0m);
        }
    }
}
