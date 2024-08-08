using System;
using System.Diagnostics;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Mithrill.MonsterBook.WebApi.Common
{
    /// <summary>
    /// For handling unknown, unexpected exceptions.
    /// </summary>
    public static class ApiExceptionHandler
    {
        private static bool _includeDetails;
        private static ILogger _logger;

        public static void UseApiExceptionHandler(
            this IApplicationBuilder app,
            IHostEnvironment environment,
            ILoggerFactory loggerFactory)
        {
            _includeDetails = environment.IsDevelopment();
            _logger = loggerFactory.CreateLogger(typeof(ApiExceptionHandler));

            app.Run(WriteResponse);
        }

        private static async Task WriteResponse(HttpContext httpContext)
        {
            var exceptionDetails = httpContext.Features.Get<IExceptionHandlerFeature>();
            var exception = exceptionDetails?.Error;

            if (exception == null)
            {
                return;
            }

            httpContext.Response.ContentType = Constants.MimeType.ApplicationProblemJson;

            var problemDetailsToLog = CreateProblemDetails(httpContext, includeDetails: true, exception);
            _logger.LogError("Error: {@ProblemDetails}", problemDetailsToLog);

            var problemDetailsToReply = CreateProblemDetails(httpContext, _includeDetails, exception);
            var stream = httpContext.Response.Body;

            await JsonSerializer.SerializeAsync(stream, problemDetailsToReply);
        }

        private static ProblemDetailsWithTraceId CreateProblemDetails(
            HttpContext httpContext,
            bool includeDetails,
            Exception exception)
        {
            const string defaultErrorMessage = "An error occurred in Offers Engine API while processing your request.";
            var request = httpContext.Request;

            var problemDetails = new ProblemDetailsWithTraceId
            {
                Type = "https://tools.ietf.org/html/rfc7231#section-6.6.1",
                Status = StatusCodes.Status500InternalServerError,
                Title = includeDetails ? exception.Message : defaultErrorMessage,
                Detail = includeDetails ? exception.ToString() : null,
                Instance = $"{request.Method} {request.Scheme}://{request.Host}{request.Path}{request.QueryString}"
            };

            var traceId = Activity.Current?.Id ?? httpContext.TraceIdentifier;
            problemDetails.Extensions["traceId"] = traceId;

            return problemDetails;
        }
    }
}