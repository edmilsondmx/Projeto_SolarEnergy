using System.ComponentModel.DataAnnotations;
using SolarEnergy.Api.Models;

namespace SolarEnergy.Api.DTOs;

public class UnidadeDto
{
    public int Id { get; set; }
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

    public UnidadeDto(Unidade unidade)
    {
        Id = unidade.Id;
        Apelido = unidade.Apelido;
        Local = unidade.Local;
        Marca = unidade.Marca;
        Modelo = unidade.Modelo;
        IsActive = unidade.IsActive;
    }
    public UnidadeDto()
    {
        
    }

}
