using Microsoft.AspNetCore.Diagnostics;
using System.Net;
using System.Text.Json;
using System.Text.Json.Serialization;
using WebApplication1.Model;

namespace WebApplication1.ErrorHandling
{
    public class GlobalExceptionHandler : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }

        }

        private async Task HandleExceptionAsync(HttpContext context, Exception ex)
        {
            ErrorModel model = new ErrorModel();
            switch (ex)
            {
                case ArgumentNullException:
                    model.message = "ArgumentNullException";
                    context.Response.StatusCode = 404;
                    break;
                case NotImplementedException:
                    model.message = "NotImplementedException";
                    context.Response.StatusCode = 401;
                    break;
                default:
                    model.message = "deafult exception";
                    context.Response.StatusCode = 400;
                    break;
            }
            context.Response.ContentType = "application/json";
            var message = JsonSerializer.Serialize(model);
            await context.Response.WriteAsync(message);
        }
    }
}
