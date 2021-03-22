using System.Net.Http;
using System.Threading.Tasks;

namespace CurrencyConverter.Services
{
    internal class RequestService : IRequestService
    {
        private readonly HttpClient _client;

        public RequestService()
        {
            _client = new HttpClient();
        }

        public async Task<string> Get(string url)
        {
            var response = await _client.GetAsync(url);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsStringAsync();
        }
    }
}
