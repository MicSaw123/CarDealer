using System.Net;

namespace CarDealer.Middlewares
{
    public class ExceptionHandlerMiddleware : AbstractExceptionHandlerMiddleware
    {
        public ExceptionHandlerMiddleware(RequestDelegate next) : base(next)
        {
        }

        public override (HttpStatusCode statusCode, string message) GetResponse(Exception exception)
        {
            return (HttpStatusCode.InternalServerError, exception.Message);
        }
    }
}
