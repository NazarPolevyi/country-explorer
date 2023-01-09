using CountryExplorer.Adapters.Models;
using Refit;

namespace CountryExplorer.Adapters
{
    public interface ICountryApi
    {
        [Get("/all")]
        Task<List<Country>> GetAllCountries();

        [Get("/name/{searchName}?fullText=true")]
        Task<List<Country>> Get(string searchName);
    }
}