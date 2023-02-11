using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using SolarEnergy.Domain.DTOs;
using SolarEnergy.Domain.Exceptions;
using SolarEnergy.Domain.Interfaces.Repositories;
using SolarEnergy.Domain.Interfaces.Services;
using SolarEnergy.Domain.Models;

namespace SolarEnergy.Domain.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;
    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }
    public void Delete(int id)
    {
        UserDto userDb = GetById(id);
        _userRepository.Delete(new User(userDb));
    }

    public IList<UserDto> Get()
    {
        return _userRepository.Get().Select(u => new UserDto(u)).ToList();
    }

    public UserDto GetById(int id)
    {
        User userDb = _userRepository.GetById(id);
        if(userDb == null) 
            throw new UserNaoEncontradoException("Usuário não encontrado");

        return new UserDto(userDb);
    }

    public Tuple<string, string, string> GetUser(LoginDto loginDto)
    {
        if (loginDto.Email == null || loginDto.Password == null)
            throw new NoDataException("Email ou senha não preenchidos");

        User userDb = _userRepository.VerifyLogin(new Login(loginDto));

        if(userDb == null) 
            throw new UserNaoEncontradoException("Usuário não encontrado");

        var token = TokenService.GenerateToken(userDb);
        var refreshToken = TokenService.GenerateRefreshToken();
        TokenService.SaveRefreshToken(userDb.Nome, refreshToken);

        return new Tuple<string, string, string>(token, refreshToken, userDb.Nome);      
    }

    public void Post(UserDto user)
    {
        if(UserJaCadastrado(user))
            throw new Exception("Usuário já cadastrado!");

        _userRepository.Post(new User(user));
    }
    private bool UserJaCadastrado(UserDto user)
    {
        bool existsUser = _userRepository.Get().Any(u => u.Email == user.Email);
        return existsUser;
    }

    public void Put(UserDto user)
    {
        User userDb = _userRepository.GetById(user.Id);
        if(userDb == null) 
            throw new UserNaoEncontradoException("Usuário não encontrado");

        userDb.Update(user);

        _userRepository.Put(userDb);
    }

    public Tuple<string, string> RefreshToken(string token, string refreshToken)
    {
        var principal = TokenService.GetPrincipalFromExpiredToken(token);
        var userName = principal.Identity.Name;
        var SaveRefreshToken = TokenService.GetRefreshToken(userName);

        if(SaveRefreshToken != refreshToken)
            throw new SecurityTokenException("Token Inválido!");

        var newToken = TokenService.GenerateToken(principal.Claims);
        var newRefreshToken = TokenService.GenerateRefreshToken();
        TokenService.DeleteRefreshToken(userName, refreshToken);
        TokenService.SaveRefreshToken(userName, newRefreshToken);

        return new Tuple<string, string>(newToken, newRefreshToken);
    }
}
