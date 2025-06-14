using System;
using Server.Data.Entities;
using Server.Dtos;

namespace Server.Interfaces;

public interface IAuthService
{
    Task<User?> SignupAsync(UserSignupDto dto);
    Task<string?> LoginAsync(UserLoginDto dto);
}
