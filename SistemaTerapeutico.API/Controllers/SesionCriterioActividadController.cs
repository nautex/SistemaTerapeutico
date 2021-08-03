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
            var sesionCriterioActividades = _sesionCriterioActividadService.GetSesionesCriteriosActividades();
            var sesionCriterioActividadesDto = _mapper.Map<IEnumerable<SesionCriterioActividadDto>>(sesionCriterioActividades);
            var response = new ApiResponse<IEnumerable<SesionCriterioActividadDto>>(sesionCriterioActividadesDto);

            return Ok(response);
        }
        [HttpPost("PostSesionCriterioActividad")]
        public async Task<IActionResult> PostSesionCriterioActividad(SesionCriterioActividadDto sesionCriterioActividadDto)
        {
            SesionCriterioActividad sesionCriterioActividad = _mapper.Map<SesionCriterioActividad>(sesionCriterioActividadDto);
            await _sesionCriterioActividadService.AddSesionCriterioActividad(sesionCriterioActividad);
            var response = new ApiResponse<bool>(true);

            return Ok(response);
        }
    }
}
