using System.Net;
namespace BlogApiProject.Middleware;
public class RequestLoggingMiddleware
{
    private readonly RequestDelegate _next;
    public RequestLoggingMiddleware (RequestDelegate next)
    {
        _next=next;
    }
    public async Task InvokeAsync(HttpContext context)
    {
        Console.WriteLine ($"Request:{context.Request.Method}");
        await _next(context);
        Console.WriteLine($"Response{context.Response.StatusCode}");
    }
}