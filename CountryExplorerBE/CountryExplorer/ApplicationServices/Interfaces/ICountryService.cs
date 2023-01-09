using CountryExplorer.Adapters.Models;

namespace CountryExplorer.ApplicationServices.Interfaces
{
    public interface ICountryService
    {
        Task<List<Country>> GetAll();

        Task<List<Country>> Get(string name);
    }
}
