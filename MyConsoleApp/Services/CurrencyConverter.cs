using System;

namespace MyConsoleApp.Services
{
    public abstract class CurrencyConverter
    {
        protected virtual decimal Convert(decimal currency, decimal course)
        {
            return Math.Round(currency / course, 2);
        }
    }
}