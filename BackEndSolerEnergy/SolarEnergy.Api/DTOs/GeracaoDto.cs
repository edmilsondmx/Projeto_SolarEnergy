using System.ComponentModel.DataAnnotations;

namespace SolarEnergy.Api.DTOs;

public class GeracaoDto
{
    [Required(ErrorMessage = "A data é obrigatória")]
    [StringLength(7, MinimumLength = 7, ErrorMessage = "A data deve conter ano e mês(2022-05)")]
    public string Data { get; set; }
    [Required(ErrorMessage = "O Kw é obrigatório")]
    public int Kw { get; set; }
    [Required(ErrorMessage = "O Id da Unidade é obrigatório")]
    [Range(1, int.MaxValue)]
    public int UnidadeId { get; set; }
}
