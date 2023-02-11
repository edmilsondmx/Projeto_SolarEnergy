using SolarEnergy.Domain.DTOs;
using SolarEnergy.Domain.Enuns;

namespace SolarEnergy.Domain.Models;

public class User
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string Image { get; set; }
    public Permissoes Role { get; set; }

    public User(UserDto user)
    {
        Id = user.Id;
        Nome = user.Nome;
        Email = user.Email;
        Password = user.Password;
        Image = user.Image;
        Role = user.Role;
    }
    public User()
    {
        
    }

    public void Update(UserDto user)
    {
        Id = user.Id;
        Nome = user.Nome;
        Email = user.Email;
        Password = user.Password;
        Role = user.Role;
    }
}
