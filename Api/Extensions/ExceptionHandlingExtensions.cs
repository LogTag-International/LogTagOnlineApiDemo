using System.Text.Json;

namespace Api.Extensions;

internal static class ExceptionHandlingExtensions
{
    public static IApplicationBuilder UseExceptionHandleMiddleware(this IApplicationBuilder builder)
    {
        return builder.UseMiddleware<ExceptionHandleMiddleware>();
    }

    sealed class ExceptionHandleMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionHandleMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception ex)
            {
                await HandleException(ex, httpContext);
            }
        }

        private static async Task HandleException(Exception ex, HttpContext httpContext)
        {
            httpContext.Response.StatusCode = StatusCodes.Status400BadRequest;
            await httpContext.Response.WriteAsJsonAsync(GetExceptionMessage(ex));
        }

        private static string GetExceptionMessage(Exception ex) => ex switch
        {
            BadHttpRequestException => "Invalid input",
            JsonException => "Json Error",
            HttpRequestException => "Unable to communicate with server",
            _ => "Unknown error"
        };
    }
}
