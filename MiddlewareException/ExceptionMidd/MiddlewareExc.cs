using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Net;
using System.Threading.Tasks;

namespace MiddlewareException.ExceptionMidd
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class MiddlewareExc
    {
        private readonly RequestDelegate _next;

        public MiddlewareExc(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext)
        {

            try
            {

                await _next(httpContext);
                string mesaj = "[Response]   HTTP  " + httpContext.Request.Method +
                    "  -  " + httpContext.Request.Path + "  Selammm";
                await httpContext.Response.WriteAsync(mesaj);

            }
          
            catch (Exception ex)
            {
                httpContext.Response.ContentType = "application/json";
                httpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
      
                var result = JsonConvert.SerializeObject(new { Errorr = ex.Message }, Formatting.None);
                await httpContext.Response.WriteAsync(result);
            }




        }

  
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class MiddlewareExcExtensions
    {
        public static IApplicationBuilder UseMiddlewareExc(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<MiddlewareExc>();
        }
    }
}
