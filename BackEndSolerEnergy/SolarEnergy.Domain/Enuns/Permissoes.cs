using System.ComponentModel.DataAnnotations;

namespace SolarEnergy.Domain.Enuns;

public enum Permissoes
{
    [Display(Name = "Admin")]
    Admin,
    [Display(Name = "User")]
    User
}
