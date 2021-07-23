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
    public class SesionCriterioActividadController : Controller
    {
        private readonly ISesionCriterioActividadService _sesionCriterioActividadService;
        private readonly IMapper _mapper;
        public SesionCriterioActividadController(ISesionCriterioActividadService sesionCriterioActividadService, IMapper mapper)
        {
            _sesionCriterioActividadService = sesionCriterioActividadService;
            _mapper = mapper;
        }
        [HttpGet("GetSesionesCriteriosActividades")]
        public IActionResult GetSesionesCriteriosActividades()
        {
            var response = new ApiResponse<IEnumerable<SesionCriterioActividad>>(_sesionCriterioActividadService.GetSesionesCriteriosActividades());

            return Ok(response);
        }
        [HttpPost("PostSesionCriterioActividad")]
        public async Task<IActionResult> PostSesionCriterioActividad(SesionCriterioActividadDto sesionCriterioActividadDto)
        {
            SesionCriterioActividad entity = new SesionCriterioActividad(sesionCriterioActividadDto.UsuarioRegistro)
            {
                Id = sesionCriterioActividadDto.IdSesionCriterio,
                IdTwo = sesionCriterioActividadDto.IdActividad,
                Orden = sesionCriterioActividadDto.Orden,
                DetalleAplicacion = sesionCriterioActividadDto.DetalleAplicacion
            };
            await _sesionCriterioActividadService.AddSesionCriterioActividad(entity);
            var response = new ApiResponse<bool>(true);

            return Ok(response);
        }
    }
}
