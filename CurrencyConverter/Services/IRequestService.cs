using System.Threading.Tasks;

namespace CurrencyConverter.Services
{
    internal interface IRequestService
    {
        Task<string> Get(string url);
    }
}