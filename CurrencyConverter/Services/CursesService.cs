using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;
using CurrencyConverter.Models;

namespace CurrencyConverter.Services
{
    internal class CursesService : ICursesService
    {
        private const string Url = "https://www.cbr-xml-daily.ru/daily_json.js";
        private readonly IRequestService _requestService;

        public CursesService(IRequestService requestService)
        {
            _requestService = requestService;
        }

        public async Task<Dictionary<string, Valute>> GetValutes()
        {
            var jsonString = await _requestService.Get(Url);
            var responseObject = JsonSerializer.Deserialize<Response>(jsonString);

            return responseObject?.Valutes;
        }
    }
}