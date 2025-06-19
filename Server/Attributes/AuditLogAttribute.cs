using System;

namespace Server.Attributes;

[AttributeUsage(AttributeTargets.Method)]
public class AuditLogAttribute(string message) : Attribute
{
    private readonly string _message = message;

    public void Comment()
    {
        Console.WriteLine($"Audit - ${_message}");
    }
}
