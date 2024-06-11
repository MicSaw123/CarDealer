using CarDealer.Domain.Errors.Responses;
using Serilog;
using System.Net;
using System.Reflection;

namespace CarDealer.Middlewares
{
    public abstract class AbstractExceptionHandlerMiddleware
    {
        private static readonly Serilog.ILogger Logger = Log.ForContext(MethodBase.GetCurrentMethod()?.DeclaringType);

        private readonly RequestDelegate _next;

        public abstract (HttpStatusCode statusCode, string message) GetResponse(Exception exception);

        public AbstractExceptionHandlerMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception exception)
            {
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                var errorResponse = ErrorResponse.CreateResponse(exception.Message, HttpStatusCode.InternalServerError);
                await context.Response.WriteAsJsonAsync(errorResponse);
            }
        }
    }
}
