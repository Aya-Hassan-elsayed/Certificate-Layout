using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;

namespace Certificit.PL.Error
{
    public class ApiServerErrorMidleWar
    {
        public RequestDelegate NextMiddleware { get; }
        public ILogger<ApiServerErrorMidleWar> Logger { get; }
        public IHostEnvironment Env { get; }
        public ApiServerErrorMidleWar(RequestDelegate NextMiddleware, ILogger<ApiServerErrorMidleWar> logger , IHostEnvironment hostEnvironment)
        {
            this.NextMiddleware = NextMiddleware;
            Logger = logger;
            Env = hostEnvironment;
        }
        public async Task InvokeAsync(HttpContext context) // Must Be This Method with Name InvokeAsync
        {
            try
            {
               await NextMiddleware.Invoke(context); // If No Exception will Invoke Next Midlle War
            }
            catch (Exception ex)
            {
                Logger.LogError(ex , ex.Message); // Log Error In Console

                // log ex in Data Base

                context.Response.ContentType = "application/json";
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

                var ExceptionErrorResponse = Env.IsDevelopment() ?
                    new ApiServerError(500, ex.Message, ex.StackTrace.ToString()) :
                    new ApiServerError(500); // Check if Env in Devploment or Not

                var option = new JsonSerializerOptions() { PropertyNamingPolicy = JsonNamingPolicy.CamelCase }; // to set Names of Property Camel Case 
                var json = JsonSerializer.Serialize(ExceptionErrorResponse , option);

               await context.Response.WriteAsync(json); // Return Json 
            }
        }
    }
}
