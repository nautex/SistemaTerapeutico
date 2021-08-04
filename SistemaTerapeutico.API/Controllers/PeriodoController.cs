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
    public class PeriodoController : Controller
    {
        private readonly IPeriodoService _periodoService;
        private readonly IMapper _mapper;
        public PeriodoController(IPeriodoService periodoService, IMapper mapper)
        {
            _periodoService = periodoService;
            _mapper = mapper;
        }
        [HttpPost("PostPeriodo")]
        public async Task<IActionResult> PostPeriodo(PeriodoDto periodoDto)
        {
            Periodo periodo = _mapper.Map<Periodo>(periodoDto);
            var response = new ApiResponse<int>(await _periodoService.AddPeriodo(periodo));

            return Ok(response);
        }
        [HttpGet("GetPeriodos")]
        public IActionResult GetPeriodos()
        {
            var list = _periodoService.GetPeriodos();
            var response = new ApiResponse<IEnumerable<PeriodoDto>>(list, _mapper);

            return Ok(response);
        }
        [HttpGet("GetPeriodoById")]
        public async Task<IActionResult> GetPeriodoById(int idPeriodo)
        {
            var entity = await _periodoService.GetPeriodoById(idPeriodo);
            var response = new ApiResponse<PeriodoDto>(entity, _mapper);

            return Ok(response);
        }
        [HttpGet("GetPeriodosByIdTipo")]
        public async Task<IActionResult> GetPeriodosByIdTipo(int idTipo)
        {
            var list = await _periodoService.GetPeriodosByIdTipo(idTipo);
            var response = new ApiResponse<IEnumerable<PeriodoDto>>(list, _mapper);

            return Ok(response);
        }
    }
}
