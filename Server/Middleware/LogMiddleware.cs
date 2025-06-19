using System;

namespace Server.Middleware;

public class LogMiddleware(RequestDelegate next, string token)
{
    private readonly RequestDelegate _next = next;
    private readonly string _token = token;
    public Task InvokeAsync(HttpContext context)
    {
        Console.WriteLine($"Log Middleware {_token}");
        return _next(context);
    }
}

public static class LogMiddlewareExtension
{
    public static IApplicationBuilder UseLogMiddleware(this IApplicationBuilder app, string token)
    {
        return app.UseMiddleware<LogMiddleware>(token);
    }
}
