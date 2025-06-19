using System;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Server.Attributes;

namespace Server.Middleware;

public class AuditMiddleware(RequestDelegate next)
{
    private readonly RequestDelegate _next = next;


    public async Task InvokeAsync(HttpContext context)
    {
        var endpoint = context.GetEndpoint();
        var hasAttr = endpoint?.Metadata.GetMetadata<AuditLogAttribute>() != null;
        if (hasAttr)
        {
            context.Items["Audit"] = true;
            Console.WriteLine($"🔍 Audit Start: {context.Request.Method} {context.Request.Path}");
        }
        await _next(context);
        if (hasAttr)
        {
            var statusCode = context.Response.StatusCode;
            Console.WriteLine($"✅ Audit Complete: Status {statusCode}");
        }
    }
}

public static class AuditMiddlewareExtension
{
    public static IApplicationBuilder UseAuditMiddleware(this IApplicationBuilder app)
    {
        return app.UseMiddleware<AuditMiddleware>();
    }
}
