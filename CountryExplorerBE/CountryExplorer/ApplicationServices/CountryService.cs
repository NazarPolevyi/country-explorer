using CountryExplorer.Adapters;
using CountryExplorer.Adapters.Models;
using CountryExplorer.ApplicationServices.Interfaces;
using Polly;
using Refit;

namespace CountryExplorer.ApplicationServices
{
    public class CountryService : ICountryService
    {
        private readonly ICountryApi _countryApi;
        private readonly ILogger<CountryService> _logger;

        public CountryService(ICountryApi countryApi, ILogger<CountryService> logger)
        {
            _countryApi = countryApi;
            _logger = logger;
        }

        public async Task<List<Country>> GetAll()
        {
            return await Policy
               .Handle<ApiException>(ex => ex.InnerException.Message.Any())
               .RetryAsync(5, async (exception, retryCount) =>
               {
                   _logger.LogWarning("Executing RetryPolicy...");

               }).ExecuteAsync(() => _countryApi.GetAllCountries());
        }

        public async Task<List<Country>> Get(string name)
        {
            return await Policy
               .Handle<ApiException>(ex => ex.InnerException.Message.Any())
               .RetryAsync(5, async (exception, retryCount) =>
               {
                   _logger.LogWarning("Executing RetryPolicy...");

               }).ExecuteAsync(() => _countryApi.Get(name));
        }
    }
}
