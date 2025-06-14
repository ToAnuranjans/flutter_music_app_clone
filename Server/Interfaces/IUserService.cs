using System;
using Server.Data.Entities;

namespace Server.Interfaces;

public interface IUserService
{
    Task<User> GetUserById(int id);
}
