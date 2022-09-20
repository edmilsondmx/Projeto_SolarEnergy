namespace SolarEnergy.Domain.Exceptions;

public class UserNaoEncontradoException : Exception
{
    public UserNaoEncontradoException(string erro) : base(erro)
    {
        
    }
}
