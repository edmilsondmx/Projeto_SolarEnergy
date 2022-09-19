using SolarEnergy.Domain.Enuns;

namespace SolarEnergy.Domain.DTOs;

public class UserDto
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public Permissoes Role { get; set; }
}
