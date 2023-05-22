using Application.Exceptions;
using Application.Models;
using Microsoft.AspNetCore.Http;
using System.Net;

namespace Application.Middleware
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(httpContext, ex);
            }
        }

        private async Task HandleExceptionAsync(HttpContext httpContext, Exception ex)
        {
            HttpStatusCode statusCode = HttpStatusCode.InternalServerError;
            ExceptionDetails exceptionDetails = new();

            switch (ex)
            {
                case BadRequestException badRequestException:
                    statusCode = HttpStatusCode.BadRequest;
                    exceptionDetails = new ExceptionDetails
                    {
                        Title = badRequestException.Message,
                        Status = (int)statusCode,
                        Detail = badRequestException.InnerException?.ToString(),
                        Type = nameof(BadRequestException),
                        Errors = badRequestException.Errors
                    };
                    break;

                case NotFoundException notFoundException:
                    statusCode = HttpStatusCode.NotFound;
                    exceptionDetails = new ExceptionDetails
                    {
                        Title = notFoundException.Message,
                        Status = (int)statusCode,
                        Detail = notFoundException.InnerException?.ToString(),
                        Type = nameof(NotFoundException),
                        Errors = notFoundException.Errors
                    };
                    break;
                default:
                    exceptionDetails = new ExceptionDetails
                    {
                        Title = ex.Message,
                        Status = (int)statusCode,
                        Type = nameof(HttpStatusCode.InternalServerError),
                        Detail = ex.StackTrace,
                    };
                    break;
            }

            httpContext.Response.StatusCode = (int)statusCode;
            await httpContext.Response.WriteAsJsonAsync(exceptionDetails);
        }
    }
}
