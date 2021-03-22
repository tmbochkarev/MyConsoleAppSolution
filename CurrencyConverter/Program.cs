using System.Runtime.CompilerServices;
using CurrencyConverter.Database;
using Microsoft.Extensions.DependencyInjection;
using CurrencyConverter.Services;

[assembly: InternalsVisibleTo("DynamicProxyGenAssembly2")]
[assembly: InternalsVisibleTo("CurrencyConverter.Test")]

namespace CurrencyConverter
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var services = ConfigureServices();
            var serviceProvider = services.BuildServiceProvider();

            serviceProvider.GetService<App>()?.Start();
        }

        private static IServiceCollection ConfigureServices()
        {
            IServiceCollection services = new ServiceCollection();

            services.AddScoped<IRubleConverter, EuroConverter>();
            services.AddScoped<IRubleConverter, DollarConverter>();
            services.AddScoped<IRequestService, RequestService>();
            services.AddScoped<ICursesService, CursesService>();
            services.AddScoped<Services.CurrencyConverter>();

            services.AddTransient<DbContext>();
            services.AddTransient<App>();

            return services;
        }
    }
}