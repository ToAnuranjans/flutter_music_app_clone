using System;
using Microsoft.EntityFrameworkCore;
using Server.Data;
using Server.Data.Entities;
using Server.Dtos;
using Server.Helpers;
using Server.Interfaces;

namespace Server.Services;

public class AuthService(AppDbContext context, JwtHelper jwt) : IAuthService
{
    private readonly AppDbContext _context = context;
    private readonly JwtHelper _jwt = jwt;

    public async Task<User?> SignupAsync(UserSignupDto dto)
    {
        if (await _context.Users.AnyAsync(u => u.Email == dto.Email))
            return null;

        var user = new User
        {
            Email = dto.Email,
            Name = dto.Name,
            PasswordHash = BCrypt.Net.BCrypt.HashPassword(dto.Password)
        };

        _context.Users.Add(user);
        await _context.SaveChangesAsync();
        return user;
    }

    public async Task<string?> LoginAsync(UserLoginDto dto)
    {
        var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == dto.Email);
        if (user == null || !BCrypt.Net.BCrypt.Verify(dto.Password, user.PasswordHash))
            return null;

        return _jwt.GenerateToken(user);
    }
}
