using System.Net;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using Refit;

namespace CountryExplorer.Exceptions
{
    public class ApiExceptionHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ApiExceptionHandlingMiddleware> _logger;

        public ApiExceptionHandlingMiddleware(RequestDelegate next, ILogger<ApiExceptionHandlingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        private Task HandleExceptionAsync(HttpContext context, Exception ex) => ex switch
        {
            ApiException e => HandleApiExceptionAsync(context, e),
            _ => InternalServerExceptionAsync(context, ex)
        };

        private Task HandleApiExceptionAsync(HttpContext context, ApiException ex)
        {
            var problemDetails = new ValidationProblemDetails(new Dictionary<string, string[]> { { "Error", new[] { ex.Message } } })
            {
                Type = "Bad request",
                Title = "One or more errors occurred.",
                Status = (int)ex.StatusCode,
                Instance = context.Request.Path,
            };

            context.Response.StatusCode = (int)ex.StatusCode;
            var result = JsonSerializer.Serialize(problemDetails);

            context.Response.ContentType = "application/problem+json";
            return context.Response.WriteAsync(result);
        }

        private Task InternalServerExceptionAsync(HttpContext context, Exception ex)
        {
            _logger.LogError(ex, $"An unhandled exception has occurred, {ex.Message}");

            var problemDetails = new Microsoft.AspNetCore.Mvc.ProblemDetails
            {
                Title = "Internal Server Error",
                Status = (int)HttpStatusCode.InternalServerError,
                Instance = context.Request.Path,
                Detail = "Internal server error occured!"
            };

            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            var result = JsonSerializer.Serialize(problemDetails);

            context.Response.ContentType = "application/problem+json";
            return context.Response.WriteAsync(result);
        }
    }
}
