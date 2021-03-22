using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using CurrencyConverter.Models;
using CurrencyConverter.Services;

namespace CurrencyConverter.Database
{
    internal class DbSingleton
    {
        private static Lazy<DbSingleton> _lazyInstance;
        private readonly ICursesService _cursesService;

        private DbSingleton(ICursesService cursesService)
        {
            _cursesService = cursesService;
        }

        public Dictionary<string, Valute> Valutes { get; set; }

        public async Task<DbSingleton> GetInstanceAsync(ICursesService cursesService)
        {
            await LazyInitializer(cursesService);
            return _lazyInstance.Value;
        }

        private async Task LazyInitializer(ICursesService cursesService)
        {
            _lazyInstance = new Lazy<DbSingleton>(() => new DbSingleton(cursesService),
                LazyThreadSafetyMode.ExecutionAndPublication);
            Valutes = await _lazyInstance.Value._cursesService.GetValutes();
        }
    }
}