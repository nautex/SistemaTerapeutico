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
    public class SesionController : Controller
    {
        private readonly ISesionService _sesionService;
        private readonly IMapper _mapper;
        public SesionController(ISesionService sesionService, IMapper mapper)
        {
            _sesionService = sesionService;
            _mapper = mapper;
        }
        [HttpPost("PostSesion")]
        public async Task<IActionResult> PostSesion(SesionDto sesionDto)
        {
            Sesion sesion = new Sesion(sesionDto.UsuarioRegistro)
            {
                IdTerapia = sesionDto.IdTerapia,
                IdPeriodoTerapia = sesionDto.IdPeriodoTerapia,
                Fecha = sesionDto.Fecha,
                Observacion = sesionDto.Observacion,
                IdEstadoAsistencia = sesionDto.IdEstadoAsistencia,
                IdPuntuacion = sesionDto.IdPuntuacion
            };
            var response = new ApiResponse<int>(await _sesionService.AddSesion(sesion));
            return Ok(response);
        }
        [HttpGet("GetSesiones")]
        public IActionResult GetSesiones()
        {
            var response = new ApiResponse<IEnumerable<Sesion>>(_sesionService.GetSesiones());
            return Ok(response);
        }
        [HttpGet("GetSesionesByIdTerapia")]
        public async Task<IActionResult> GetSesionesByIdTerapia(int idTerapia)
        {
            var response = new ApiResponse<IEnumerable<Sesion>>(await _sesionService.GetSesionesByIdTerapia(idTerapia));
            return Ok(response);
        }
        [HttpGet("GetSesionesByIdPeriodoTerapia")]
        public async Task<IActionResult> GetSesionesByIdPeriodoTerapia(int idPeriodoTerapia)
        {
            var response = new ApiResponse<IEnumerable<Sesion>>(await _sesionService.GetSesionesByIdPeriodoTerapia(idPeriodoTerapia));
            return Ok(response);
        }
    }
}
