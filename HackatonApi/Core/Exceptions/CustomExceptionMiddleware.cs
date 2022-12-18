using System.Diagnostics;
using System.Net;
using HackatonApi.Core.Services.Logger;
using FluentValidation;
using Newtonsoft.Json;

namespace ChefApi.Core.Middleware;

public class CustomExceptionMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILoggerService _loggerService;
    public CustomExceptionMiddleware(RequestDelegate next, ILoggerService loggerService)
    {
        _next = next;
        _loggerService = loggerService;
    }
    public async Task Invoke(HttpContext context)
    {
        var watch = Stopwatch.StartNew();
        try
        {
            string message = "[Request] " + context.Request.Method + " - " + context.Request.Path;
            _loggerService.Write(message);
            await _next.Invoke(context);
            watch.Stop();
            message = "[Response] " + context.Request.Method + " - " + context.Request.Path + " responded " + context.Response.StatusCode + " in " + watch.ElapsedMilliseconds + "ms";
            _loggerService.Write(message);
        }
        catch (Exception ex)
        {
            watch.Stop();
            await HandleException(context, ex, watch);
        }
    }

    public Task HandleException(HttpContext context, Exception ex, Stopwatch watch)
    {
        context.Response.ContentType = "application/json";

        if (ex is ValidationException)
        {
            context.Response.StatusCode = (int)HttpStatusCode.UnprocessableEntity;
        }
        else if (ex is InvalidOperationException)
        {
            context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
        }
        else if (ex is HttpRequestException)
        {
            context.Response.StatusCode = (int)(ex as HttpRequestException)!.StatusCode!;
        }
        else if (ex is UnauthorizedAccessException)
        {
            context.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
        }
        else
        {
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
        }

        string message = "[Error] " + context.Request.Method + " - " + context.Request.Path + " responded " + context.Response.StatusCode + " Error Message: " + ex.Message + " in " + watch.Elapsed.TotalMilliseconds + "ms";
        _loggerService.Write(message);

        var result = JsonConvert.SerializeObject(new { error = ex.Message }, Formatting.None);
        return context.Response.WriteAsync(result);
    }
}