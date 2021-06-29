using FirstStepsDotNet.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TransportMastersGameApi.Middleware
{
    public class ErrorHandlingMiddleware : IMiddleware
    {
        private readonly ILogger<ErrorHandlingMiddleware> _logger;

        public ErrorHandlingMiddleware(ILogger<ErrorHandlingMiddleware> logger) // wstrzykuje ilogera odpowiadającego za wyłapytanie i logowanie błędów
        {
            _logger = logger;
        }
        public async Task InvokeAsync(HttpContext context, RequestDelegate next) 
        {
            try
            {
                await next.Invoke(context);
            }
            catch (BadRequestExceprion badRequestExceprion)
            {
                context.Response.StatusCode = 400;
                await context.Response.WriteAsync(badRequestExceprion.Message); //to dostanie klient jako komunikat błedu zamiast informacji co zle wpisał 
            }
            catch (NotFoundException notFoundException)
            {
                context.Response.StatusCode = 404;
                await context.Response.WriteAsync(notFoundException.Message); //to dostanie klient jako komunikat błedu zamiast 
            }
            catch (Exception e)
            {
                _logger.LogError(e, e.Message);
                context.Response.StatusCode = 500; //kod statusu 
                await context.Response.WriteAsync("Something went wrong"); //to dostanie klient jako komunikat błedu zamiast 
            }

        }
    }
}
