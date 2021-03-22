using CurrencyConverter.Constants;
using CurrencyConverter.Database;

namespace CurrencyConverter.Services
{
    internal class EuroConverter : CurrencyConverter, IRubleConverter
    {
        private const string ValuteKey = ValuteConstants.EUR;

        private readonly DbContext _context;

        public EuroConverter(DbContext context)
        {
            _context = context;
        }

        public decimal FromRubles(decimal rubles)
        {
            return Convert(rubles, _context.GetCurse(ValuteKey) ?? -1);
        }
    }
}
