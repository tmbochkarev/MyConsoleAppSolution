using System.Linq;
using CurrencyConverter.Models;
using CurrencyConverter.Services;

namespace CurrencyConverter.Database
{
    internal class DbContext
    {
        private static DbSingleton _dbSingleton;

        public DbContext(ICursesService cursesService)
        {
            _dbSingleton = DbSingleton.GetInstanceAsync(cursesService)
                .ConfigureAwait(false)
                .GetAwaiter()
                .GetResult();
        }

        public Valute[] Valutes => _dbSingleton.Valutes.Select(x => x.Value).ToArray();

        public Valute GetValute(string valuteKey)
        {
            return _dbSingleton.Valutes.ContainsKey(valuteKey) ? _dbSingleton.Valutes[valuteKey] : null;
        }

        public decimal? GetCurse(string valuteKey)
        {
            if (_dbSingleton.Valutes.ContainsKey(valuteKey))
            {
                return _dbSingleton.Valutes[valuteKey].Value;
            }

            return null;
        }
    }
}
