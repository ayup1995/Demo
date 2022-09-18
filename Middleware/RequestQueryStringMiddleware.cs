using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace introAspNetCore.Middleware
{
    public class RequestQueryStringMiddleware
    {
        RequestDelegate next;
        public RequestQueryStringMiddleware(RequestDelegate nextDelegate)
        {
            next = nextDelegate;
        }
        public async Task Invoke(HttpContext context)
        {
            if (context.Request.Method == HttpMethods.Get
                && context.Request.Query["iscertifoed"] == "true")
            {
                await context.Response.WriteAsync("message from class-based Middleware \n");
            }
            await next(context);
        }
    }
}
