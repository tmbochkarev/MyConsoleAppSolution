using System.Collections.Generic;
using System.Threading.Tasks;
using CurrencyConverter.Models;

namespace CurrencyConverter.Services
{
    internal interface ICursesService
    {
        Task<Dictionary<string, Valute>> GetValutes();
    }
}