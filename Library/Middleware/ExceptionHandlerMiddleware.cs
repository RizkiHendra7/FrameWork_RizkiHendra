using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using RizkiHendraFrameWork.Common.Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace RizkiHendraFrameWork.Library.Middleware
{
    public static class ExceptionMiddlewareExtensions
    { 
        public static void ImplementExceptionHandlerMiddleware(this IApplicationBuilder app)
        {
            app.UseMiddleware<ExceptionMiddleware>();
        } 
    }
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next; 
        public ExceptionMiddleware(RequestDelegate next )
        { 
            _next = next;
        }
        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception ex)
            { 
                #region inject error into return api model
                clsReturnApi result = new clsReturnApi();
                result.bitSuccess = false;
                result.boolError = true;
                result.txtStackTrace = ex.StackTrace;
                result.txtErrorMessage = ex.Message;
                #endregion

                await HandleExceptionAsync(httpContext, result);
            }
        }
        private async Task HandleExceptionAsync(HttpContext context, clsReturnApi result)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            await context.Response.WriteAsync(Newtonsoft.Json.JsonConvert.SerializeObject(result));
        }
    } 

} 
