using Nanis.Shared.Exceptions;
using System.ComponentModel.DataAnnotations;
using System.Net;

namespace Spa.Api.Middleware
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionMiddleware> _logger;

        public ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context); 
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An unhandled exception occurred.");
                await HandleExceptionAsync(context, ex);
            }
        }

        private Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            context.Response.ContentType = "application/json";
            var (statusCode, message) = exception switch
            {
                EntityNullException _ => ((int)HttpStatusCode.BadRequest, "The entity entered cannot be null"),
                ValidationException _ => ((int)HttpStatusCode.BadRequest, "Invalid data provided."),
                ArgumentNullException _ => ((int)HttpStatusCode.BadRequest, "Required parameter is missing."),
                UnauthorizedAccessException _ => ((int)HttpStatusCode.Unauthorized, "You are not authorized to access this resource."),
                KeyNotFoundException _ => ((int)HttpStatusCode.NotFound, "The requested resource could not be found."),
                InvalidOperationException _ => ((int)HttpStatusCode.Forbidden, "The operation is not allowed."),
                _ => ((int)HttpStatusCode.InternalServerError, "An unexpected error occurred.")
            }; ;

            context.Response.StatusCode = statusCode;

            var errorResponse = new
            {
                IsSuccess = false,
                Message = message,
                ErrorDetails = exception.Message ,
                InnerException = exception.InnerException.Message
            };

            return context.Response.WriteAsJsonAsync(errorResponse);
        }
    }
}
