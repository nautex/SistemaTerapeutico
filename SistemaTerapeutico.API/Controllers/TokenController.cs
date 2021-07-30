using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using SistemaTerapeutico.Core.Entities;
using SistemaTerapeutico.Core.Interfaces;

namespace SistemaTerapeutico.API.Controllers
{
    [Route("[controller]")]
    public class TokenController : Controller
    {
        private readonly IConfiguration _configuration;
        private readonly IUsuarioService _usuarioService;
        private readonly IPasswordService _passwordService;
        public TokenController(IConfiguration configuration, IUsuarioService usuarioService, IPasswordService passwordService)
        {
            _configuration = configuration;
            _usuarioService = usuarioService;
            _passwordService = passwordService;
        }
        [HttpPost]
        public async Task<IActionResult> Authentication([FromBody] UserLogin login)
        {
            var validation = await IsValidUser(login);

            if (validation.Item1)
            {
                var token = GenerateToken(validation.Item2);
                return Ok(new { token });
            }

            return NotFound();
        }
        private async Task<(bool, Usuario)> IsValidUser(UserLogin login)
        {
            var user = await _usuarioService.GetUsuarioByCodigoYClave(login.User, login.Password);
            var isValid = _passwordService.Check(user.Clave, login.Password);

            return (isValid, user);
        }
        private string GenerateToken(Usuario usuario)
        {
            //Header
            var _symetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Authentication:SecretKey"]));
            var signingCredentials = new SigningCredentials(_symetricSecurityKey, SecurityAlgorithms.HmacSha256);
            var header = new JwtHeader(signingCredentials);

            //Claims
            var claims = new[]
            {
                new Claim(ClaimTypes.Name, usuario.Codigo),
                new Claim(ClaimTypes.Email, "jjgeorgeh@gmail.com"),
                new Claim(ClaimTypes.Role, "Administrator")
            };

            //Payload
            var payload = new JwtPayload
            (
                _configuration["Authentication:Issuer"],
                _configuration["Authentication:Audience"],
                claims,
                DateTime.Now,
                DateTime.UtcNow.AddMinutes(10)
            );

            //Signature
            var token = new JwtSecurityToken(header, payload);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
