using System;

namespace Server.Services;

public interface ICurrentUserService
{
    int UserId { get; }
}
