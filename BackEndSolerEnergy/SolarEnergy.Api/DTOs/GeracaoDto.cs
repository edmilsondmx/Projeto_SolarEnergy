using System.ComponentModel.DataAnnotations;

namespace SolarEnergy.Api.DTOs;

public class GeracaoDto
{
    [Required(ErrorMessage = "A data é obrigatória")]
    [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd-MM-yyyy}")]
    [DataType(DataType.Date, ErrorMessage = "Data em formato inválido")]
    public DateTime Data { get; set; }
    [Required(ErrorMessage = "O Kw é obrigatório")]
    public int Kw { get; set; }
    [Required(ErrorMessage = "O Id da Unidade é obrigatório")]
    [Range(1, int.MaxValue)]
    public int UnidadeId { get; set; }
}
