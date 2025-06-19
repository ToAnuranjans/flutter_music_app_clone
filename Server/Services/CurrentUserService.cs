using System;
using System.Security.Claims;

namespace Server.Services;

public class CurrentUserService : ICurrentUserService
{
    public int UserId { get; }


    public CurrentUserService(IHttpContextAccessor httpContext)
    {
        var userIdClaim = httpContext.HttpContext?.User?.FindFirst(ClaimTypes.NameIdentifier);
        if (userIdClaim != null)
        {
            UserId = int.Parse(userIdClaim.Value);
        }
    }
}
