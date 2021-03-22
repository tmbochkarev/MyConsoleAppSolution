using System.Linq;
using CurrencyConverter.Models;
using CurrencyConverter.Services;

namespace CurrencyConverter.Database
{
    internal class DbContext
    {
        private readonly DbSingleton _dbSingleton;

        public DbContext(ICursesService cursesService)
        {
            _dbSingleton.GetInstanceAsync(cursesService)
                .ConfigureAwait(false)
                .GetAwaiter()
                .GetResult();
        }

        public Valute[] Valutes => _dbSingleton.Valutes.Select(x => x.Value).ToArray();
    }
}
