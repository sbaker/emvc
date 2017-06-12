using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Emvc.Middleware
{
    public class EmvcMiddleware
    {
        private RequestDelegate _next;
        private ILogger<EmvcMiddleware> _logger;

        public EmvcMiddleware(ILoggerFactory loggerFactory, RequestDelegate next)
        {
            _logger = loggerFactory.CreateLogger<EmvcMiddleware>();
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            _logger.LogInformation("Emvc.Middleware begin pipeline.");

            await _next.Invoke(context);

            _logger.LogInformation("Emvc.Middleware end pipeline.");
        }
    }
}
