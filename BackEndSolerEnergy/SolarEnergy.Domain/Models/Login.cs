using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SolarEnergy.Domain.DTOs;

namespace SolarEnergy.Domain.Models
{
    public class Login
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public Login(string email, string password)
        {
            Email = email;
            Password = password;
        }
        public Login(LoginDto loginDto)
        {
            Email = loginDto.Email;
            Password = loginDto.Password;
        }
        public Login()
        {

        }

        
    }
}