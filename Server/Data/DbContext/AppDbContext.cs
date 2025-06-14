using System;
using Microsoft.EntityFrameworkCore;
using Server.Data.Entities;

namespace Server.Data;

public class AppDbContext(DbContextOptions options) : DbContext(options)
{
    public DbSet<User> Users { get; set; }
}
