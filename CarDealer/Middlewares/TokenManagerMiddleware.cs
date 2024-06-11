using CarDealer.Application.Interfaces.Services.Identity;
using System.Net;

namespace CarDealer.Middlewares
{
    public class TokenManagerMiddleware
    {
        private readonly ITokenManagerService _tokenManager;
        private readonly RequestDelegate _next;

        public TokenManagerMiddleware(ITokenManagerService tokenManager, RequestDelegate next)
        {
            _tokenManager = tokenManager;
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            if (await _tokenManager.IsCurrentTokenActive())
            {
                await _next(context);
                return;
            }
            context.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
        }
    }
}
