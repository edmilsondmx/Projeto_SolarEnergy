
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SolarEnergy.Domain.DTOs;
using SolarEnergy.Domain.Enuns;
using SolarEnergy.Domain.Interfaces.Services;
using SolarEnergy.Domain.Services;

namespace SolarEnergy.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UsersController : ControllerBase
{
    private readonly IUserService _userService;
    public UsersController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpGet]
    public IActionResult ListUsers()
    {
        return Ok(ConverterRole.ToDto(_userService.Get()));
    }

    [HttpGet("{idUser}")]
    public IActionResult ListById(
        [FromRoute] int idUser
    )
    {
        return Ok(ConverterRole.ToDto(_userService.GetById(idUser)));
    }

    [HttpPost]
    public IActionResult CreateUser(
        [FromBody] UserDto user
    )
    {
        _userService.Post(user);
        return Created("api/users", user);
    }

    [Authorize(Roles = "Admin")]
    [HttpPut("{idUser}")]
    public IActionResult UpdateUser(
        [FromRoute] int idUser,
        [FromBody] UserDto user
    )
    {
        user.Id = idUser;
        _userService.Put(user);
        return Ok();
    }

    [Authorize(Roles = "Admin")]
    [HttpDelete("{idUser}")]
    public IActionResult DeleteUser(
        [FromRoute] int idUser
    )
    {
        _userService.Delete(idUser);
        return NoContent();
    }
}
