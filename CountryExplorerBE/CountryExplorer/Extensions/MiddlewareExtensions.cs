using CountryExplorer.Exceptions;

namespace CountryExplorer.Extensions
{
    internal static class MiddlewareExtensions
    {
        internal static IApplicationBuilder UseApiExceptionHandling(this IApplicationBuilder app) => app.UseMiddleware<ApiExceptionHandlingMiddleware>();
    }
}
