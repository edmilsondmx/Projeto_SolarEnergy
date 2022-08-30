namespace SolarEnergy.Api.Models;

public class Geracao
{
    public int Id { get; set; }
    public string Data { get; set; }
    public int Kw { get; set; }
    public int UnidadeId { get; set; }
    public Unidade Unidade { get; set; }
    public Geracao(string data, int kw, int unidadeId)
    {
        Data = data;
        Kw = kw;
        UnidadeId = unidadeId;
    }
    public Geracao()
    {
        
    }
}
