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
    public class TerapiaPeriodoController : Controller
    {
        private readonly ITerapiaPeriodoService _terapiaPeriodoService;
        private readonly IMapper _mapper;
        public TerapiaPeriodoController(ITerapiaPeriodoService terapiaPeriodoService, IMapper mapper)
        {
            _terapiaPeriodoService = terapiaPeriodoService;
            _mapper = mapper;
        }
        [HttpPost("PostTerapiaPeriodo")]
        public async Task<IActionResult> PostTerapiaPeriodo(TerapiaPeriodoDto terapiaPeriodoDto)
        {
            TerapiaPeriodo entity = new TerapiaPeriodo(terapiaPeriodoDto.Usuario)
            {
                Id = terapiaPeriodoDto.IdTerapia,
                IdTwo = terapiaPeriodoDto.IdPeriodo,
                IdComprobante = terapiaPeriodoDto.IdComprobante,
            };
            await _terapiaPeriodoService.AddTerapiaPeriodo(entity);
            var response = new ApiResponse<bool>(true);

            return Ok(response);
        }
        [HttpGet("GetTerapiasPeriodos")]
        public IActionResult GetTerapiasPeriodos()
        {
            var list = _terapiaPeriodoService.GetTerapiasPeriodos();
            var response = new ApiResponse<IEnumerable<TerapiaPeriodo>>(list);

            return Ok(response);
        }
        [HttpGet("GetTerapiaPeriodoByIds")]
        public async Task<IActionResult> GetTerapiaPeriodoByIds(int idTerapia, int idPeriodo)
        {
            var entity = await _terapiaPeriodoService.GetTerapiaPeriodoByIds(idTerapia, idPeriodo);
            var response = new ApiResponse<TerapiaPeriodo>(entity);

            return Ok(response);
        }
    }
}
