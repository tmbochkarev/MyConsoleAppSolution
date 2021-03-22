using MyConsoleApp.Services;

namespace MyConsoleApp.Models
{
    public class Converter
    {
        private readonly IRubleConverter _rubleConverter;

        public Converter(IRubleConverter rubleConverter)
        {
            _rubleConverter = rubleConverter;
        }

        public decimal RubleToDollarConverter(decimal rubles)
        {
            return _rubleConverter.FromRubles(rubles);
        }
    }
}
