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
    public class PeriodoTerapiaController : Controller
    {
        private readonly IPeriodoTerapiaService _periodoTerapiaService;
        private readonly IMapper _mapper;
        public PeriodoTerapiaController(IPeriodoTerapiaService periodoTerapiaService, IMapper mapper)
        {
            _periodoTerapiaService = periodoTerapiaService;
            _mapper = mapper;
        }
        [HttpPost("PostPeriodoTerapia")]
        public async Task<IActionResult> PostPeriodoTerapia(PeriodoDto periodoTerapiaDto)
        {
            Periodo periodoTerapia = new Periodo(periodoTerapiaDto.Usuario)
            {
                IdTipo = periodoTerapiaDto.IdTipo,
                Codigo = periodoTerapiaDto.Codigo,
                FechaInicio = periodoTerapiaDto.FechaInicio,
                FechaFin = periodoTerapiaDto.FechaFin,
                Observaciones = periodoTerapiaDto.Observaciones
            };
            var response = new ApiResponse<int>(await _periodoTerapiaService.AddPeriodoTerapia(periodoTerapia));
            return Ok(response);
        }
        [HttpGet("GetPeriodosTerapias")]
        public IActionResult GetPeriodosTerapias()
        {
            var response = new ApiResponse<IEnumerable<Periodo>>(_periodoTerapiaService.GetPeriodosTerapias());
            return Ok(response);
        }
        [HttpGet("GetPeriodoTerapiaById")]
        public async Task<IActionResult> GetTerapiaById(int idPeriodoTerapia)
        {
            var response = new ApiResponse<Periodo>(await _periodoTerapiaService.GetPeriodoTerapiaById(idPeriodoTerapia));
            return Ok(response);
        }
        [HttpGet("GetPeriodosTerapiasByIdTipo")]
        public async Task<IActionResult> GetPeriodosTerapiasByIdTipo(int idTipo)
        {
            var response = new ApiResponse<IEnumerable<Periodo>>(await _periodoTerapiaService.GetPeriodosTerapiasByIdTipo(idTipo));
            return Ok(response);
        }
    }
}
