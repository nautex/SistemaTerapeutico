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
    public class TerapiaPlanificacionController : Controller
    {
        private readonly ITerapiaPlanificacionService _terapiaPlanificacionService;
        private readonly IMapper _mapper;
        public TerapiaPlanificacionController(ITerapiaPlanificacionService terapiaPlanificacionService, IMapper mapper)
        {
            _terapiaPlanificacionService = terapiaPlanificacionService;
            _mapper = mapper;
        }
        [HttpPost("PostTerapiaPlanificacion")]
        public async Task<IActionResult> PostTerapiaPlanificacion(TerapiaPlanificacionDto terapiaPlanificacionDto)
        {
            TerapiaPlanificacion terapiaPlanificacion = _mapper.Map<TerapiaPlanificacion>(terapiaPlanificacionDto);
            await _terapiaPlanificacionService.AddTerapiaPlanificacion(terapiaPlanificacion);
            var response = new ApiResponse<bool>(true);

            return Ok(response);
        }
        [HttpGet("GetTerapiasPlanificaciones")]
        public IActionResult GetTerapiasPlanificaciones()
        {
            var list = _terapiaPlanificacionService.GetTerapiasPeriodos();
            var response = new ApiResponse<IEnumerable<TerapiaPlanificacionDto>>(list, _mapper);

            return Ok(response);
        }
        [HttpGet("GetTerapiaPlanificacionByIds")]
        public async Task<IActionResult> GetTerapiaPlanificacionByIds(int idTerapia, int idPeriodo)
        {
            var entity = await _terapiaPlanificacionService.GetTerapiaPlanificacionByIds(idTerapia, idPeriodo);
            var response = new ApiResponse<TerapiaPlanificacionDto>(entity, _mapper);

            return Ok(response);
        }
    }
}
