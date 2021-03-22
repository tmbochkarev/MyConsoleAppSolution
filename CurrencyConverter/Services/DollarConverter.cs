using CurrencyConverter.Constants;
using CurrencyConverter.Database;

namespace CurrencyConverter.Services
{
    internal class DollarConverter : CurrencyConverter, IRubleConverter
    {
        private const string ValuteKey = ValuteConstants.USD;

        private readonly DbContext _context;

        public DollarConverter(DbContext context)
        {
            _context = context;
        }

        public decimal FromRubles(decimal rubles)
        {
            return Convert(rubles, _context.GetCurse(ValuteKey) ?? -1);
        }
    }
}