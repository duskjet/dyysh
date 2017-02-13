using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Primitives;

namespace Dyysh.Web.Middleware
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class UserAgentRejection
    {
        private readonly RequestDelegate _next;

        private const string RejectionText = "Просто пошел нахуй отсюда.";
        private string exclusionTarget;

        public UserAgentRejection(RequestDelegate next, string exclusion)
        {
            exclusionTarget = exclusion.ToLower();
            _next = next;
        }

        public Task Invoke(HttpContext httpContext)
        {
            System.Diagnostics.Debug.WriteLine($"User-Agent: {httpContext.Request.Headers["User-Agent"]}");

            if (httpContext.Request.Headers.ContainsKey("User-Agent"))

                if (httpContext.Request.Headers["User-Agent"].Any(text => text.ToLower().Contains(exclusionTarget)))
                {
                    httpContext.Response.Headers.Add(new KeyValuePair<string, StringValues>(
                        "Content-Type", 
                        new StringValues("text/html; charset=UTF-8")));

                    return httpContext.Response.WriteAsync(RejectionText);
                }

            return _next(httpContext);
        }
    }


    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class BrowserRejectMiddlewareExtensions
    {
        public static IApplicationBuilder UseUserAgentRejection(this IApplicationBuilder builder, string exclusion)
        {
            return builder.UseMiddleware<UserAgentRejection>(exclusion);
        }
    }
}