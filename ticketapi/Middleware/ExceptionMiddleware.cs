using System.Net;
using System.Text.Json;

namespace Ticketapi.Middleware
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate next;
        private readonly ILogger<ExceptionMiddleware> logger;

        public ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger)
        {
            this.next = next;
            this.logger = logger;
        }

        // Middleware invocation
        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await next(context);
            }
            catch (Exception exception)
            {
                logger.LogError($"API Failure: {exception}");
                await HandleExceptionAsync(context, exception);
            }
        }

        // Exception handling
        private static Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            context.Response.ContentType = "application/json";

            var statusCode = exception switch
            {
                Microsoft.AspNetCore.Http.BadHttpRequestException badRequestException => (int)HttpStatusCode.BadRequest,
                Exception internalError => (int)HttpStatusCode.InternalServerError
            };

            var response = new
            {
                StatusCode = statusCode,
                Message = statusCode == (int)HttpStatusCode.BadRequest ? "Bad request." : "Internal Server Error.",
                Detailed = exception.Message
            };

            context.Response.StatusCode = statusCode;
            return context.Response.WriteAsync(JsonSerializer.Serialize(response));
        }
    }
}
