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

        public static async Task<DbSingleton> GetInstanceAsync(ICursesService cursesService)
        {
            await LazyInitializer(cursesService);
            return _lazyInstance.Value;
        }

        private static async Task LazyInitializer(ICursesService cursesService)
        {
            _lazyInstance = new Lazy<DbSingleton>(() => new DbSingleton(cursesService),
                LazyThreadSafetyMode.ExecutionAndPublication);
            _lazyInstance.Value.Valutes = await _lazyInstance.Value._cursesService.GetValutes();
        }
    }
}