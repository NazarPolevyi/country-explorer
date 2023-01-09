using System.Text.Json;
using CountryExplorer.Settings;
using Refit;

namespace CountryExplorer.Adapters
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddApiServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient<HttpLoggingHandler>();

            // API Clients
            services.AddCountryApi(configuration);

            return services;
        }

        private static IServiceCollection AddCountryApi(this IServiceCollection services, IConfiguration configuration)
        {
            var refitSettings = CreateCustomRefitSettings();

            var countrySettings = configuration.GetSection(nameof(CountrySettings)).Get<CountrySettings>();

            services.AddRefitClient<ICountryApi>()
                    .ConfigureHttpClient(client =>
                    {
                        client.BaseAddress = new Uri(countrySettings?.Url ?? string.Empty);
                    })
            .AddHttpMessageHandler<HttpLoggingHandler>();

            return services;
        }

        private static RefitSettings CreateCustomRefitSettings()
        {
            JsonSerializerOptions jsonSerializerOptions = SystemTextJsonContentSerializer.GetDefaultJsonSerializerOptions();
            jsonSerializerOptions.DefaultIgnoreCondition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull;

            return new RefitSettings
            {
                ContentSerializer = new SystemTextJsonContentSerializer(jsonSerializerOptions)
            };
        }
    }
}
