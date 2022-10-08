using SolarEnergy.Domain.DTOs;

namespace SolarEnergy.Domain.Models;

public class Unidade
{
    public int Id { get; set; }
    public string Apelido { get; set; }
    public string Local { get; set; }
    public string Marca { get; set; }
    public string Modelo { get; set; }
    public bool IsActive { get; set; }
    public virtual List<Geracao> Geracoes { get; set; }
    public Unidade(string apelido, string local, string marca, string modelo, bool isActive)
    {
        Apelido = apelido;
        Local = local;
        Marca = marca;
        Modelo = modelo;
        IsActive = isActive;
    }
    public Unidade()
    {
        
    }
    public Unidade(UnidadeDto unidade)
    {
        Id = unidade.Id;
        Apelido = unidade.Apelido;
        Local = unidade.Local;
        Marca = unidade.Marca;
        Modelo = unidade.Modelo;
        IsActive = unidade.IsActive;
    }

    public void Update(UnidadeDto unidade)
    {
        Apelido = unidade.Apelido;
        Local = unidade.Local;
        Marca = unidade.Marca;
        Modelo = unidade.Modelo;
        IsActive = unidade.IsActive;
    }
}
