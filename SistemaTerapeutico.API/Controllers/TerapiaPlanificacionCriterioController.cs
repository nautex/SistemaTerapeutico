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
    public class TerapiaPlanificacionCriterioController : Controller
    {
        private readonly ITerapiaPlanificacionCriterioService _terapiaPlanificacionCriterioService;
        private readonly IMapper _mapper;
        public TerapiaPlanificacionCriterioController(ITerapiaPlanificacionCriterioService terapiaPlanificacionCriterioService, IMapper mapper)
        {
            _terapiaPlanificacionCriterioService = terapiaPlanificacionCriterioService;
            _mapper = mapper;
        }
        [HttpPost("PostTerapiaPlanificacionCriterio")]
        public async Task<IActionResult> PostTerapiaPlanificacionCriterio(TerapiaPlanificacionCriterioDto terapiaPlanificacionCriterioDto)
        {
            TerapiaPlanificacionCriterio terapiaPlanificacionCriterio = _mapper.Map<TerapiaPlanificacionCriterio>(terapiaPlanificacionCriterioDto);
            await _terapiaPlanificacionCriterioService.AddTerapiaPlanificacionCriterio(terapiaPlanificacionCriterio);
            var response = new ApiResponse<bool>(true);

            return Ok(response);
        }
        [HttpGet("GetTerapiasPlanificacionesCriterios")]
        public IActionResult GetTerapiasPlanificacionesCriterios()
        {
            var list = _terapiaPlanificacionCriterioService.GetTerapiasPlanificacionesCriterios();
            var response = new ApiResponse<IEnumerable<TerapiaPlanificacionCriterioDto>>(list, _mapper);

            return Ok(response);
        }
        [HttpGet("GetTerapiasPlanificacionesCriteriosByIdTerapiaYIdPeriodo")]
        public async Task<IActionResult> GetTerapiasPlanificacionesCriteriosByIdTerapiaYIdPeriodo(int idTerapia, int idPeriodo)
        {
            var list = await _terapiaPlanificacionCriterioService.GetTerapiasPlanificacionesCriteriosByIdTerapiaYIdPeriodo(idTerapia, idPeriodo);
            var response = new ApiResponse<IEnumerable<TerapiaPlanificacionCriterioDto>>(list, _mapper);

            return Ok(response);
        }
    }
}
