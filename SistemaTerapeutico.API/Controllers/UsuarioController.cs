using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SistemaTerapeutico.API.Response;
using SistemaTerapeutico.Core.DTOs;
using SistemaTerapeutico.Core.Entities;
using SistemaTerapeutico.Core.Enumerators;
using SistemaTerapeutico.Core.Interfaces;

namespace SistemaTerapeutico.API.Controllers
{
    [Authorize(Roles = nameof(ERoleType.Administrator))]
    [Route("[controller]")]
    public class UsuarioController : Controller
    {
        private readonly IUsuarioService _usuarioService;
        private readonly IMapper _mapper;
        public UsuarioController(IUsuarioService usuarioService, IMapper mapper)
        {
            _usuarioService = usuarioService;
            _mapper = mapper;
        }
        [HttpPost("PostUsuario")]
        public async Task<IActionResult> PostUsuario(UsuarioDto usuarioDto)
        {
            Usuario entity = new Usuario(usuarioDto.UsuarioRegistro)
            {
                Codigo = usuarioDto.Codigo,
                Id = usuarioDto.IdPersona,
                Clave = usuarioDto.Clave
            };
            await _usuarioService.AddUsuario(entity);
            var response = new ApiResponse<bool>(true);

            return Ok(response);
        }
    }
}
