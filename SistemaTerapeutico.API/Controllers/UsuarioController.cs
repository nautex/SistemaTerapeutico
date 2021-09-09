using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SistemaTerapeutico.API.Response;
using SistemaTerapeutico.Core.DTOs;
using SistemaTerapeutico.Core.Entities;
using SistemaTerapeutico.Core.Interfaces;

namespace SistemaTerapeutico.API.Controllers
{
    //[Authorize(Roles = nameof(ERoleType.Administrator))]
    [Route("[controller]")]
    public class UsuarioController : Controller
    {
        private readonly IUsuarioService _usuarioService;
        private readonly IMapper _mapper;
        private readonly IPasswordService _passwordService;
        public UsuarioController(IUsuarioService usuarioService, IMapper mapper, IPasswordService passwordService)
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
