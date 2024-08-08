using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Mithrill.MonsterBook.Application.Common.Exceptions;

namespace Mithrill.MonsterBook.WebApi.Common
{
    /// <summary>
    /// For handling specific known, expected exceptions using the problem details standard.
    /// </summary>
    public class ExpectedExceptionFilter : ExceptionFilterAttribute
    {
        private static readonly Dictionary<Type, Func<Exception, ProblemDetails>> ExceptionsProblemDetailsFactoryMap =
            new()
            {
                {
                    typeof(NotFoundException),
                    _ => new ProblemDetails
                    {
                        Type = "https://tools.ietf.org/html/rfc7231#section-6.5.4",
                        Status = StatusCodes.Status404NotFound
                    }
                },
                {
                    typeof(ConflictException),
                    _ => new ProblemDetails
                    {
                        Type = "https://tools.ietf.org/html/rfc7231#section-6.5.8",
                        Status = StatusCodes.Status409Conflict
                    }
                },
                {
                    typeof(NotImplementedException),
                    _ => new ProblemDetails
                    {
                        Type = "https://tools.ietf.org/html/rfc7231#section-6.6.2",
                        Status = StatusCodes.Status501NotImplemented
                    }
                },
                {
                    typeof(UnauthorizedException),
                    _ => new ProblemDetails
                    {
                        Type = "https://tools.ietf.org/html/rfc7231#section-6.5.3",
                        Status = StatusCodes.Status403Forbidden
                    }
                }
            };

        public override void OnException(ExceptionContext context)
        {
            if (context.Exception.GetType() == typeof(TaskCanceledException))
                return;

            context.HttpContext.Response.ContentType = Constants.MimeType.ApplicationProblemJson;
            HandleException(context);
        }

        private static void HandleException(ExceptionContext context)
        {
            var exception = context.Exception;
            var request = context.HttpContext.Request;

            if (ExceptionsProblemDetailsFactoryMap.TryGetValue(exception.GetType(), out var createDetails))
            {
                var details = createDetails(exception);
                details.Title = exception.Message;
                details.Instance = $"{request.Method} {request.Scheme}://{request.Host}{request.Path}{request.QueryString}";

                context.Result = new ObjectResult(details) { StatusCode = details.Status };
                context.ExceptionHandled = true;
            }
        }
    }
}