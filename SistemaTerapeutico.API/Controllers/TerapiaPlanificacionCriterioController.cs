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
            TerapiaPlanificacionCriterio entity = new TerapiaPlanificacionCriterio(terapiaPlanificacionCriterioDto.UsuarioRegistro)
            {
                Id = terapiaPlanificacionCriterioDto.IdTerapia,
                IdTwo = terapiaPlanificacionCriterioDto.IdPeriodo,
                IdThree = terapiaPlanificacionCriterioDto.IdObjetivoCriterio,
                Orden = terapiaPlanificacionCriterioDto.Orden,
                IdPuntuacionDetalle = terapiaPlanificacionCriterioDto.IdPuntuacionDetalle
            };
            await _terapiaPlanificacionCriterioService.AddTerapiaPlanificacionCriterio(entity);
            var response = new ApiResponse<bool>(true);

            return Ok(response);
        }
        [HttpGet("GetTerapiasPlanificacionesCriterios")]
        public IActionResult GetTerapiasPlanificacionesCriterios()
        {
            var response = new ApiResponse<IEnumerable<TerapiaPlanificacionCriterio>>(_terapiaPlanificacionCriterioService.GetTerapiasPlanificacionesCriterios());

            return Ok(response);
        }
        [HttpGet("GetTerapiasPlanificacionesCriteriosByIdTerapiaYIdPeriodo")]
        public async Task<IActionResult> GetTerapiasPlanificacionesCriteriosByIdTerapiaYIdPeriodo(int idTerapia, int idPeriodo)
        {
            var response = new ApiResponse<IEnumerable<TerapiaPlanificacionCriterio>>(await _terapiaPlanificacionCriterioService.GetTerapiasPlanificacionesCriteriosByIdTerapiaYIdPeriodo(idTerapia, idPeriodo));

            return Ok(response);
        }
    }
}
