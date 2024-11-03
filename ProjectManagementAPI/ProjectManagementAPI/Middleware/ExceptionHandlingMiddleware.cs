using Newtonsoft.Json;
using ProjectManagement.Application.Exceptions;
using ProjectManagement.Application.Response;
using System.Net;

namespace ProjectManagementAPI.Middleware
{
    public class ExceptionHandlingMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionHandlingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        private Task HandleExceptionAsync(HttpContext context, Exception ex)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError; // Default to 500 if not handled

            var response = new Response<string>()
            {
                Success = false,
                Message = "An unexpected error occurred.",
                Error = ex.Message
            };

            // You can customize the response based on exception types
            if (ex is NotFoundException)
            {
                context.Response.StatusCode = (int)HttpStatusCode.NotFound;
                response.Message = ex.Message;
            }

            if (ex is AlreadyExistsException)
            {
                context.Response.StatusCode = (int)HttpStatusCode.Conflict;
                response.Message = ex.Message;
            }

            if (ex is UnauthorizedAccessException)
            {
                context.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
                response.Message = ex.Message;
            }
            if (ex is ArgumentException)
            {
                context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                response.Message = ex.Message;
            }
            // Here you might want to log the exception using your logging framework

            return context.Response.WriteAsync(JsonConvert.SerializeObject(response));
        }
    }
}
