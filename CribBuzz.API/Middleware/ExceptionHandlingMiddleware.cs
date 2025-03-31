using System.Net;
using System.Text.Json;
using CribBuzz.API.Exceptions;

public class ExceptionHandlingMiddleWare
{
    private readonly RequestDelegate _next;
    private readonly ILogger<ExceptionHandlingMiddleWare> _logger;
    public ExceptionHandlingMiddleWare(RequestDelegate next, ILogger<ExceptionHandlingMiddleWare> logger)
    {
        _next = next;
        _logger = logger;
    }

    public async Task Invoke(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, " An unhandled error occured" );

            var response = context.Response;
            response.ContentType = "application/json";

            var statusCode = ex switch
            {
                BadRequestException => HttpStatusCode.BadRequest,
                NotFoundException => HttpStatusCode.NotFound,
                UnauthorizedException => HttpStatusCode.Unauthorized,
                _ => HttpStatusCode.InternalServerError
            };

            response.StatusCode = (int)statusCode;


            var errorResponse = new 
            {
                message = ex.Message,
                statusCode = response.StatusCode
            };

            var jsonResponse = JsonSerializer.Serialize(errorResponse);
            await response.WriteAsync(jsonResponse);
        }
    }
   
}