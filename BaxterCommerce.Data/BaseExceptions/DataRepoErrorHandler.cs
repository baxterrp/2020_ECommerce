using BaxterCommerce.Data.Users.Exceptions;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Net;
using System.Threading.Tasks;

namespace BaxterCommerce.Data.BaseExceptions
{
    /// <summary>
    /// 
    /// </summary>
    public class DataRepoErrorHandler
    {
        private readonly RequestDelegate _next;
        public DataRepoErrorHandler(RequestDelegate next)
        {
            _next = next;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="httpContext"></param>
        /// <returns></returns>
        public async Task Invoke(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch(Exception exception)
            {
                await HandleException(httpContext, exception);
            }
        }

        private Task HandleException(HttpContext httpContext, Exception exception)
        {
            HttpStatusCode code;

            switch (exception)
            {
                case ArgumentNullException _:
                case ArgumentException _:
                case DuplicateUserException _:
                    code = HttpStatusCode.BadRequest; 
                    break;
                default:
                    code = HttpStatusCode.InternalServerError;
                    break;
            }

            var result = JsonConvert.SerializeObject(new { error = exception.Message });
            httpContext.Response.ContentType = "application/json";
            httpContext.Response.StatusCode = (int)code;

            return httpContext.Response.WriteAsync(result);
        }
    }
}
