using Product.Application.Exceptions;
using Product.Application.Models;
using System.Net;

namespace Product.API.Middlewares
{
    public class ExceptionHandlerMiddleware
    {
        private readonly RequestDelegate _next;
        public ExceptionHandlerMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (BusinessLogicException ex)
            {
                await ConfigureResponse(httpContext, HttpStatusCode.BadRequest, ex.Message);
            }
            //catch (Exception ex)
            //{
            //  //  Log.Error(ex, "There is an error");
            //    ConfigureResponse(httpContext, HttpStatusCode.OK, _generalErrorMessage);
            //}

        }


        private static async Task ConfigureResponse(HttpContext context, HttpStatusCode statusCode, string message)
        {
            context.Response.StatusCode = (int)statusCode;
            context.Response.ContentType = "application/json";

            await context.Response.WriteAsync(new ResponseMessage(message).ToString());
        }
    }

}
