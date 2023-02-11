using SolarEnergy.Domain.Enuns;
using SolarEnergy.Domain.Models;

namespace SolarEnergy.Domain.DTOs;

public class UserDto
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string Image { get; set; }
    public Permissoes Role { get; set; }

    public UserDto(User user)
    {
        Id = user.Id;
        Nome = user.Nome;
        Email = user.Email;
        Password = user.Password;
        Image = user.Image;
        Role = user.Role;
    }
    public UserDto()
    {
        
    }
}
