using CountryExplorer.Adapters.Models;
using CountryExplorer.Models;

namespace CountryExplorer.Mapping
{
    public static class CountryExtensions
    {
        public static CountryModel ToModel(this Country country)
         => country != null ?
            new CountryModel
            {
                Name = country.Name?.Common ?? string.Empty,
                Capital = country.Capital?.FirstOrDefault() ?? string.Empty,
                Region = country.Region,
                Language = country.Languages?.Values.FirstOrDefault() ?? string.Empty,
                Currency = country.Currencies?.Values.FirstOrDefault()?.Name ?? string.Empty
            }
            : null;

        public static CountryDetailsModel ToDetailsModel(this Country country)
         => country != null ?
            new CountryDetailsModel
            {
                Name = country.Name?.Common ?? string.Empty,
                Capital = country.Capital?.FirstOrDefault() ?? string.Empty,
                Region = country.Region,
                Language = country.Languages?.FirstOrDefault().Value ?? string.Empty,
                Currency = country.Currencies?.FirstOrDefault().Value.Name ?? string.Empty,
                Image = country.Flags?.Values?.FirstOrDefault() ?? string.Empty,
                MapLink = country.Maps?.Values?.FirstOrDefault() ?? string.Empty
            }
            : null;
    }
}
