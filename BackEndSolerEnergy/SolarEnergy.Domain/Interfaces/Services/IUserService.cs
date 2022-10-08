using SolarEnergy.Domain.DTOs;

namespace SolarEnergy.Domain.Interfaces.Services;

public interface IUserService
{
    IList<UserDto> Get();
    UserDto GetById(int id);
    Tuple<string, string> GetUser(LoginDto login);
    void Post(UserDto user);
    void Put(UserDto user);
    void Delete(int id);
    Tuple<string, string> RefreshToken(string token, string refreshToken);
}
