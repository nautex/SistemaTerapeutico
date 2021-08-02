using System;
using System.Collections.Generic;
using System.Linq;
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
            TerapiaPlanificacion entity = new TerapiaPlanificacion(terapiaPlanificacionDto.Usuario)
            {
                Id = terapiaPlanificacionDto.IdTerapia,
                IdTwo = terapiaPlanificacionDto.IdPeriodo,
                DetalleResultado = terapiaPlanificacionDto.DetalleResultado
            };
            await _terapiaPlanificacionService.AddTerapiaPlanificacion(entity);
            var response = new ApiResponse<bool>(true);

            return Ok(response);
        }
        [HttpGet("GetTerapiasPlanificaciones")]
        public IActionResult GetTerapiasPlanificaciones()
        {
            var response = new ApiResponse<IEnumerable<TerapiaPlanificacion>>(_terapiaPlanificacionService.GetTerapiasPeriodos());

            return Ok(response);
        }
        [HttpGet("GetTerapiaPlanificacionByIds")]
        public async Task<IActionResult> GetTerapiaPlanificacionByIds(int idTerapia, int idPeriodo)
        {
            var response = new ApiResponse<TerapiaPlanificacion>(await _terapiaPlanificacionService.GetTerapiaPlanificacionByIds(idTerapia, idPeriodo));

            return Ok(response);
        }
    }
}
