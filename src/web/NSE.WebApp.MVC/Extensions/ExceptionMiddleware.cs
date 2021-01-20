﻿using Microsoft.AspNetCore.Http;
using Polly.CircuitBreaker;
using System.Net;
using System.Threading.Tasks;

namespace NSE.WebApp.MVC.Extensions
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
            catch (CustomHttpRequestException ex)
            {
                HandlerRequestExceptionAsync(httpContext, ex);
            }
            catch (BrokenCircuitException)
            {
                HandlerRequestExceptionAsync(httpContext);
            }
        }

        private static void HandlerRequestExceptionAsync(HttpContext context, CustomHttpRequestException httpRequestException)
        {
            if (httpRequestException.StatusCode == HttpStatusCode.Unauthorized)
            {
                context.Response.Redirect($"/login?ReturnUrl={context.Request.Path}");
                return;
            }

            context.Response.StatusCode = (int)httpRequestException.StatusCode;
        }
        private static void HandlerRequestExceptionAsync(HttpContext context)
        {
            context.Response.Redirect("/sistema-indisponivel");
        }
    }
}
