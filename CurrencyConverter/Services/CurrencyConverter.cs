using System;

namespace CurrencyConverter.Services
{
    internal class CurrencyConverter
    {
        public virtual decimal Convert(decimal currency, decimal course)
        {
            return Math.Round(currency / course, 2);
        }
    }
}