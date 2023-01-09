using CountryExplorer.Adapters;
using CountryExplorer.Adapters.Models;
using CountryExplorer.ApplicationServices;
using CountryExplorer.ApplicationServices.Interfaces;
using Microsoft.Extensions.Logging;
using Moq;
using Xunit;

namespace CountryExplorer.Tests
{
    public class CountryServiceTests
    {
        private readonly Mock<ICountryApi> _countryApi;
        private readonly ICountryService _countryService;
        private List<Country> countries = new List<Country>
            {
                new Country
                {
                    Name = new Name { Common = "countryCommon", Official = "countryOfficial" },
                    Capital = new List<string>{"capital" },
                    Currencies = new Dictionary<string, Currency>() { { "usd", new Currency { Name = "currency", Symbol = "$"} } },
                    Region = "region",
                    Maps = new Dictionary<string, string> { { "googleMap","mapLink" } },
                    Flags = new Dictionary<string, string> { { "image","imageLink" } },
                    Languages = new Dictionary<string, string> { { "languageCode", "language" } }
                },
                new Country
                {
                    Name = new Name { Common = "countryCommon1", Official = "countryOfficial1" },
                    Capital = new List<string>{"capital1" },
                    Currencies = new Dictionary<string, Currency>() { { "usd1", new Currency { Name = "currency1", Symbol = "$"} } },
                    Region = "region1",
                    Maps = new Dictionary<string, string> { { "googleMap1","mapLink1" } },
                    Flags = new Dictionary<string, string> { { "image1","imageLink1" } },
                    Languages = new Dictionary<string, string> { { "languageCode1", "language1" } }
                }
            };

        public CountryServiceTests()
        {
            _countryApi = new Mock<ICountryApi>();
            _countryService = new CountryService(_countryApi.Object, new Mock<ILogger<CountryService>>().Object);
        }

        [Fact]
        public async Task GetCountriesShouldReturnAllCountries()
        {
            // Arrange
            _countryApi.Setup(x => x.GetAllCountries()).ReturnsAsync(countries);

            // Act
            var countriesList = await _countryService.GetAll();

            // Assert
            Assert.Equal(countries, countriesList);
        }

        [Fact]
        public async Task GetCountriesShouldThrowExceptionWhenClientNotAvaialble()
        {
            // Arrange
            _countryApi.Setup(x => x.GetAllCountries()).ThrowsAsync(new Exception());

            // Act
            // Assert
            await Assert.ThrowsAsync<Exception>(() => _countryService.GetAll());
        }

        [Fact]
        public async Task GetCountryByIdShouldThrowExceptionWhenClientNotAvaialble()
        {
            // Arrange
            _countryApi.Setup(x => x.Get(It.IsAny<string>())).ThrowsAsync(new Exception());

            // Act
            // Assert
            await Assert.ThrowsAsync<Exception>(() => _countryService.Get("name"));
        }

        [Fact]
        public async Task GetCountryByIdShouldReturnCountryById()
        {
            // Arrange
            _countryApi.Setup(x => x.Get(It.IsAny<string>())).ReturnsAsync(countries);

            // Act
            var countriesList = await _countryService.Get(countries.First().Name.Common);

            // Assert
            Assert.Equal(countriesList, countries);
        }
    }
}