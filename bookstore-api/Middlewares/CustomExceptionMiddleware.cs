using bookstore_api.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Diagnostics;
using System.Net;
using System.Threading.Tasks;

namespace bookstore_api.Middlewares
{
    public class CustomExceptionMiddleware
    {
        private readonly RequestDelegate next;
        private readonly ILoggerService logger;

        public CustomExceptionMiddleware(RequestDelegate next, ILoggerService logger)
        {
            this.next = next;
            this.logger = logger;
        }

        public async Task Invoke(HttpContext context)
        {
            var watch = Stopwatch.StartNew();
            try
            {
                string message = "[Request]   HTTP " + context.Request.Method + " - " + context.Request.Path;
                logger.Write(message);

                await next.Invoke(context);

                watch.Stop();
                message = "[Response]  HTTP " + context.Request.Method + " - " + context.Request.Path + " responded " + context.Response.StatusCode + " in " + watch.Elapsed.TotalMilliseconds + " ms";
                logger.Write(message);
            }
            catch (Exception ex)
            {
                watch.Stop();
                await HandleExceptionAsync(context, ex, watch);
            }
        }

        public Task HandleExceptionAsync(HttpContext context, Exception ex, Stopwatch watch)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            string message = "[Error]     HTTP " + context.Request.Method + " - " + context.Request.Path + " - responded " + context.Response.StatusCode + " Error Message: " + ex.Message + " in " + watch.Elapsed.TotalMilliseconds + " ms";
            logger.Write(message);

            var result = JsonConvert.SerializeObject(new { error = ex.Message }, Formatting.None);

            return context.Response.WriteAsync(result);
        }
    }

    public static class CustomExceptionMiddlewareExtension
    {
        public static IApplicationBuilder UseCustomExceptionMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<CustomExceptionMiddleware>();
        }
    }
}