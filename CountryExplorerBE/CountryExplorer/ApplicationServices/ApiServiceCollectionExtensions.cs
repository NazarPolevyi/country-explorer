using CountryExplorer.ApplicationServices.Interfaces;

namespace CountryExplorer.ApplicationServices;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddServices(this IServiceCollection services)
    {
        services.AddTransient<ICountryService, CountryService>();

        return services;
    }
}
