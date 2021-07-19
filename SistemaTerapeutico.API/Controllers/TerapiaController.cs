using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SistemaTerapeutico.API.Response;
using SistemaTerapeutico.Core.DTOs;
using SistemaTerapeutico.Core.Entities;
using SistemaTerapeutico.Core.Interfaces;

namespace SistemaTerapeutico.API.Controllers
{
    [Route("[controller]")]
    public class TerapiaController : Controller
    {
        private readonly ITerapiaService _terapiaService;
        private readonly IMapper _mapper;
        public TerapiaController(ITerapiaService terapiaServices, IMapper mapper)
        {
            _terapiaService = terapiaServices;
            _mapper = mapper;
        }
        [HttpPost("PostTerapia")]
        public async Task<IActionResult> PostTerapia(TerapiaDto terapiaDto)
        {
            Terapia lTerapia = new Terapia(terapiaDto.UsuarioRegistro)
            {
                IdAtencion = terapiaDto.IdAtencion,
                IdTipo = terapiaDto.IdTipo,
                FechaInicio = terapiaDto.FechaInicio,
                IdLugar = terapiaDto.IdLugar
            };
            var Response = new ApiResponse<int>(await _terapiaService.AddTerapia(lTerapia));
            return Ok(Response);
        }
        [HttpGet("GetTerapias")]
        public IActionResult GetTerapias()
        {
            var response = new ApiResponse<IEnumerable<Terapia>>(_terapiaService.GetTerapias());
            return Ok(response);
        }
        [HttpGet("GetTerapiasByIdAtencion")]
        public async Task<IActionResult> GetTerapiasByIdAtencion(int idAtencion)
        {
            var response = new ApiResponse<IEnumerable<Terapia>>(await _terapiaService.GetTerapiasByIdAtencion(idAtencion));
            return Ok(response);
        }
    }
}
