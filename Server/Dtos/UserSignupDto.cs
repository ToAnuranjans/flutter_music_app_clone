using System;

namespace Server.Dtos;

public class UserSignupDto
{
    public string? Name { get; set; }         
    public string? Email { get; set; }
    public string? Password { get; set; }
}
