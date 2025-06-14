using System;
using Microsoft.EntityFrameworkCore;
using Server.Data;
using Server.Data.Entities;
using Server.Interfaces;

namespace Server.Services;

public class UserService(AppDbContext context) : IUserService
{
    private readonly AppDbContext _context = context;

    public async Task<User> GetUserById(int id)
    {
        var user = await _context.Users.FirstOrDefaultAsync(u => u.Id == id) ?? throw new Exception("User not found");
        return user;
    }
}
