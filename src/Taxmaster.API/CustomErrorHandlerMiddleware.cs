namespace Taxmaster.API;

public class CustomErrorHandlerMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<CustomErrorHandlerMiddleware> _logger;

    public CustomErrorHandlerMiddleware(RequestDelegate next, ILogger<CustomErrorHandlerMiddleware> logger)
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
            _logger.LogError($"Something went wrong: {ex.Message}");
            await HandleExceptionAsync(context, ex);
        }
    }

    private async Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
        context.Response.ContentType = "application/json";
        var (statuscode, message) = exception switch
        {
            TaxPolicyNotFound t => (StatusCodes.Status404NotFound, $"No tax policy for municipality '{t.Name}' at date {t.Date.ToShortDateString()}."),
            _ => (StatusCodes.Status500InternalServerError, "Unknown Error")
        };
        context.Response.StatusCode = statuscode;

        var response = $$"""{"error": "{{message}}"}""";

        await context.Response.WriteAsync(response);
    }
}
