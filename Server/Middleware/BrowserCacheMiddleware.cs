using System;

namespace Server.Middleware;

public class BrowserCacheMiddleware(RequestDelegate next, string token) 
{
    private readonly RequestDelegate _next = next;

    private readonly string _token = token;

    public Task InvokeAsync(HttpContext context)
    {
        Console.WriteLine($"Browser cache {_token}");
        return _next(context);
    }
}


public static class BrowserCacheMiddlewareExtension
{
    public static IApplicationBuilder UseBrowserCacheMiddleware(this IApplicationBuilder app, string token)
    {
        return app.UseMiddleware<BrowserCacheMiddleware>(token);
    }
}