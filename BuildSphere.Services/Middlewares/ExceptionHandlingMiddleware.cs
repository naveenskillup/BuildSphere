using System.Net;
using System.Text.Json;
using BuildSphere.Common.Exceptions;

namespace BuildSphere.Services.Middlewares
{
    public class ExceptionHandlingMiddleware
    {
        public ExceptionHandlingMiddleware(RequestDelegate next)
            => _next = next;

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch(BuildSphereHttpException ex)
            {
                await WriteErrorResponse(context, ex.StatusCode, ex.Error);
            }
            catch(Exception ex)
            {
                await WriteErrorResponse(context, (int)HttpStatusCode.InternalServerError, "An unexpected error occurred.");
            }
        }

        private static async Task WriteErrorResponse(HttpContext context, int statusCode, string errorMessage)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = statusCode;
            var response = new
            {
                StatusCode = statusCode,
                Error = errorMessage
            };

            await context.Response.WriteAsync(JsonSerializer.Serialize(response));
        }

        private readonly RequestDelegate _next;
    }
}
