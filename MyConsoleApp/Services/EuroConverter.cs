namespace MyConsoleApp.Services
{
    public class EuroConverter : CurrencyConverter, IRubleConverter
    {
        public decimal FromRubles(decimal rubles)
        {
            // todo: получение из базы или внешнего источника
            const decimal course = 88.72m;
            return Convert(rubles, course);
        }
    }
}
