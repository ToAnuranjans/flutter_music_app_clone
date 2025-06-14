using System;
using Server.Data.Entities;

namespace Server.Dtos;

public class UserDto(User user)
{
    public int Id { get; set; } = user.Id;
    public string? Name { get; set; } = user.Name;
    public string? Email { get; set; } = user.Email;
}
