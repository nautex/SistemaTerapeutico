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
    public class SesionCriterioController : Controller
    {
        private readonly ISesionCriterioService _sesionCriterioService;
        private readonly IMapper _mapper;
        public SesionCriterioController(ISesionCriterioService sesionCriterioService, IMapper mapper)
        {
            _sesionCriterioService = sesionCriterioService;
            _mapper = mapper;
        }
        [HttpGet("GetSesionesCriterios")]
        public IActionResult GetSesionesCriterios()
        {
            var list = _sesionCriterioService.GetSesionesCriterios();
            var listDto = _mapper.Map<IEnumerable<SesionCriterioDto>>(list);
            var response = new ApiResponse<IEnumerable<SesionCriterioDto>>(listDto);

            return Ok(response);
        }
        [HttpPost("PostSesionCriterio")]
        public async Task<IActionResult> PostSesionCriterio(SesionCriterioDto sesionCriterioDto)
        {
            SesionCriterio sesionCriterio = _mapper.Map<SesionCriterio>(sesionCriterioDto);
            var response = new ApiResponse<int>(await _sesionCriterioService.AddSesionCriterio(sesionCriterio));

            return Ok(response);
        }
        [HttpGet("GetSesionesCriteriosByIdSesion")]
        public async Task<IActionResult> GetSesionesCriteriosByIdSesion(int idSesion)
        {
            var list = await _sesionCriterioService.GetSesionesCriteriosByIdSesion(idSesion);
            var listDto = _mapper.Map<IEnumerable<SesionCriterioDto>>(list);
            var response = new ApiResponse<IEnumerable<SesionCriterioDto>>(listDto);

            return Ok(response);
        }
    }
}
