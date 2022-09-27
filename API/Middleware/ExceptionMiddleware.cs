using System.Net;
using System.Text.Json;
using Applicattion.Core;

namespace API.Middleware;

public class ExceptionMiddleware
{
  private readonly RequestDelegate _next;
  private readonly ILogger<ExceptionMiddleware> _logger;
  public ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger)
  {
    _logger = logger;
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
      // Log the exception
      _logger.LogError(ex, ex.Message);

      // create the exception response
      context.Response.ContentType = "application/json";
      context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
      var response = new AppException(context.Response.StatusCode, ex.Message);

      // format the JSON exception response
      var options = new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase };
      var json = JsonSerializer.Serialize(response, options);
      await context.Response.WriteAsync(json);
    }
  }
}