using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace TransportMastersGameApi.Middleware
{
    public class RequestTimeMidleware : IMiddleware
    {
        // w tym midlleware mierze czas wykonania zapytania jeżeli jest większy niz 4sec zapisuje do logów informacje o tym 

        private Stopwatch _stopWatch;
        private readonly ILogger<RequestTimeMidleware> _logger;

        public RequestTimeMidleware(ILogger<RequestTimeMidleware> logger)
        {
            _stopWatch = new Stopwatch();
            _logger = logger;
        }
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            _stopWatch.Start();
            await next.Invoke(context);
            _stopWatch.Stop();

            var elapsedMilliseconds = _stopWatch.ElapsedMilliseconds;
            if(elapsedMilliseconds / 1000 > 4) 
            {
                var message =
                    $"Request [{context.Request.Method}] at {context.Request.Path} took {elapsedMilliseconds} ms";
                _logger.LogInformation(message);
            }
        }
    }
}
