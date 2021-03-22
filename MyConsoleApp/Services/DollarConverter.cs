namespace MyConsoleApp.Services
{
    public class DollarConverter : CurrencyConverter, IRubleConverter
    {
        public decimal FromRubles(decimal rubles)
        {
            // todo: получение из базы или внешнего источника
            const decimal course = 74.25m;
            return Convert(rubles, course);
        }
    }
}