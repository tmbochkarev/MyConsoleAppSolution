using CurrencyConverter.Services;
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
            var converter = new DollarConverter();
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
            var converter = new DollarConverter();
            var result = converter.FromRubles(rubles);

            _testOutputHelper.WriteLine($"result: {result}");
            Assert.True(result != 0m);
        }
    }
}
