using CurrencyConverter.Database;
using CurrencyConverter.Services;
using Moq;
using Xunit;
using Xunit.Abstractions;

namespace CurrencyConverter.Test
{
    public class CurrencyConverterTest
    {
        private const string JsonString =
            "{\"Valute\":{\"AUD\":{\"ID\":\"R01010\",\"NumCode\":\"036\",\"CharCode\":\"AUD\",\"Nominal\":1,\"Name\":\"Австралийский доллар\",\"Value\":57.6127,\"Previous\":57.5541}}}";

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
            var requestService = new Mock<IRequestService>();
            requestService.Setup(x => x.Get(It.IsAny<string>()))
                .ReturnsAsync(JsonString);
            var cursesService = new CursesService(requestService.Object);

            var dbContext = new DbContext(cursesService);
            var converter = new DollarConverter(dbContext);
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
            var requestService = new Mock<IRequestService>();
            requestService.Setup(x => x.Get(It.IsAny<string>()))
                .ReturnsAsync(JsonString);
            var cursesService = new CursesService(requestService.Object);

            var dbContext = new DbContext(cursesService);
            var converter = new DollarConverter(dbContext);
            var result = converter.FromRubles(rubles);

            _testOutputHelper.WriteLine($"result: {result}");
            Assert.True(result != 0m);
        }
    }
}