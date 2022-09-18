using System.ComponentModel.DataAnnotations;

namespace SolarEnergy.Api.DTOs;

public class UnidadeDto
{
    [Required(ErrorMessage = "O apelido é obrigatório")]
    public string Apelido { get; set; }
    [Required(ErrorMessage = "O local é obrigatório")]
    public string Local { get; set; }
    [Required(ErrorMessage = "a marca é obrigatória")]
    public string Marca { get; set; }
    [Required(ErrorMessage = "O modelo é obrigatório")]
    public string Modelo { get; set; }
    [Required(ErrorMessage = "Campo é obrigatório")]
    public bool IsActive { get; set; }
}
