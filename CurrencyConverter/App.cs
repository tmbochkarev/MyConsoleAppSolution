using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using CurrencyConverter.Database;
using CurrencyConverter.Services;

namespace CurrencyConverter
{
    internal class App
    {
        private readonly DbContext _context;
        private readonly Services.CurrencyConverter _converter;
        private readonly IRubleConverter _dollarConverter;
        private readonly IRubleConverter _euroConverter;

        public App(IEnumerable<IRubleConverter> rubleConverters, DbContext context, Services.CurrencyConverter converter)
        {
            _context = context;
            _converter = converter;
            _dollarConverter = rubleConverters.FirstOrDefault(x => x.GetType() == typeof(DollarConverter));
            _euroConverter = rubleConverters.FirstOrDefault(x => x.GetType() == typeof(EuroConverter));
        }

        public void Start()
        {
            Console.WriteLine("Input your number: ");
            // TODO: вынести в отдельный сервис
            var rubles = Convert.ToDecimal(Console.ReadLine(), CultureInfo.InvariantCulture);

            var dollar = ConvertToEuro(rubles);
            var euro = ConvertToDollar(rubles);

            // TODO: это тоже можно! вынести в сервис
            Console.WriteLine($"Dollar is {dollar} for {rubles} rubles. Euro is {euro} for {rubles} rubles");

            ShowAllConverts(rubles);
        }

        private void ShowAllConverts(decimal rubles)
        {
            var valutes = _context.Valutes;
            Console.WriteLine($"Other conversions:");
            foreach (var valute in valutes)
            {
                var value = _converter.Convert(rubles, valute.Value);
                Console.WriteLine($"{valute.Name}: {value}");
            }
        }

        private decimal ConvertToEuro(decimal rubles)
        {
            return _euroConverter.FromRubles(rubles);
        }

        private decimal ConvertToDollar(decimal rubles)
        {
            return _dollarConverter.FromRubles(rubles);
        }
    }
}