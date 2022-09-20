using SolarEnergy.Domain.DTOs;
using SolarEnergy.Domain.Enuns;

namespace SolarEnergy.Domain.Services;

public static class ConverterRole
{
    public static RoleDto ToDto(UserDto user)
    {
        return new RoleDto{
            Id = user.Id,
            Nome = user.Nome,
            Email = user.Email,
            Role = user.Role.GetName()
        };
    }
    public static IList<RoleDto> ToDto(IList<UserDto> listDto)
    {
        return listDto.Select(f => ToDto(f)).ToList();
    } 
    
}
