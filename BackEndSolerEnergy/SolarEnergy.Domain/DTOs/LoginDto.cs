using SolarEnergy.Domain.Models;

namespace SolarEnergy.Domain.DTOs;

public class LoginDto
{
    public string Email { get; set; }
    public string Password { get; set; }

    public LoginDto(string email, string password)
    {
        Email = email;
        Password = password;
    }
    public LoginDto(Login login)
    {
        Email = login.Email;
        Password = login.Password;
    }
    public LoginDto()
    {

    }
}
