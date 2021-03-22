using System;

namespace MyConsoleApp.Services
{
    internal abstract class CurrencyConverter
    {
        protected virtual decimal Convert(decimal currency, decimal course)
        {
            return Math.Round(currency / course, 2);
        }
    }
}