using System.Text.Json;

namespace Api.Extensions;

// Custom Global Exception Handling. Inspired by: https://medium.com/@fahrican.kcn/mastering-exception-handling-and-logging-in-net-7-minimal-api-with-serilog-8fa46d5a3251
internal static class ExceptionHandlingExtensions
{
    public static IApplicationBuilder UseExceptionHandleMiddleware(this IApplicationBuilder builder) =>
        builder.UseMiddleware<ExceptionHandleMiddleware>();

    private sealed class ExceptionHandleMiddleware
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
                await ex.HandleException(httpContext);
            }
        }
    }

    // For example purposes only
    private static (int statusCode, string message) GetExceptionMessageAndStatusCode(this Exception ex) => ex switch
    {
        BadHttpRequestException => (StatusCodes.Status400BadRequest, "Invalid input"),
        JsonException => (StatusCodes.Status400BadRequest, "Json Error"),
        HttpRequestException => (StatusCodes.Status400BadRequest, "Unable to communicate with server"),
        _ => (StatusCodes.Status500InternalServerError, "Unknown error")
    };

    private async static Task HandleException(this Exception ex, HttpContext httpContext)
    {
        (int statusCode, string message) = ex.GetExceptionMessageAndStatusCode();
        httpContext.Response.StatusCode = statusCode;
        await httpContext.Response.WriteAsJsonAsync(message);
    }
}
