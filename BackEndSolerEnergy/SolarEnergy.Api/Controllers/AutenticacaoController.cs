using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SolarEnergy.Domain.DTOs;
using SolarEnergy.Domain.Interfaces.Services;
using SolarEnergy.Domain.Services;

namespace SolarEnergy.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AutenticacaoController : ControllerBase
{
    private readonly IUserService _userService;

    public AutenticacaoController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpPost]
    [Route("login")]
    public IActionResult Login(
        [FromBody] LoginDto login
    )
    {
        return Ok(_userService.GetUser(login));
    }

    [HttpPost]
    [Route("refresh-token")]
    [AllowAnonymous]
    public IActionResult Refresh(
        [FromQuery] string token,
        [FromQuery] string refreshToken
    )
    {
        
        return Ok(_userService.RefreshToken(token, refreshToken));
    }
}
