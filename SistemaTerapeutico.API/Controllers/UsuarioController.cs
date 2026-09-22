using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SistemaTerapeutico.API.Response;
using SistemaTerapeutico.Core.DTOs;
using SistemaTerapeutico.Core.Entities;
using SistemaTerapeutico.Core.Interfaces;
using SistemaTerapeutico.Infrastucture.Services;

namespace SistemaTerapeutico.API.Controllers
{
    //[Authorize(Roles = nameof(ERoleType.Administrator))]
    [Route("[controller]")]
    public class UsuarioController : Controller
    {
        private readonly UsuarioService _usuarioService;
        private readonly IMapper _mapper;
        private readonly PasswordService _passwordService;
        public UsuarioController(UsuarioService usuarioService, IMapper mapper, PasswordService passwordService)
        {
            _usuarioService = usuarioService;
            _mapper = mapper;
            _passwordService = passwordService;
        }
        [HttpPost("PostUsuario")]
        public async Task<IActionResult> PostUsuario(UsuarioDto usuarioDto)
        {
            Usuario entity = new Usuario()
            {
                Codigo = usuarioDto.Codigo,
                Id = usuarioDto.IdPersona,
                Clave = _passwordService.Hash(usuarioDto.Clave)
            };
            await _usuarioService.AddUsuario(entity);
            var response = new ApiResponse<bool>(true);

            return Ok(response);
        }
    }
}
