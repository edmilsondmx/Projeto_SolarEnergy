namespace SolarEnergy.Api.Models;

public class Unidade
{
    public int Id { get; set; }
    public string Apelido { get; set; }
    public string Local { get; set; }
    public string Marca { get; set; }
    public string Modelo { get; set; }
    public bool IsActive { get; set; }
    public List<Geracao> Geracoes { internal get; set; }
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
}
