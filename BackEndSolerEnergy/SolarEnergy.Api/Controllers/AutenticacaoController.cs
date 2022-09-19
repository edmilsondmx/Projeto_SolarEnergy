using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SolarEnergy.Domain.DTOs;
using SolarEnergy.Domain.Interfaces.Services;

namespace SolarEnergy.Api.Controllers
{
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
            _userService.ObterUsuario(login);
            return Ok();
        }
    }
}