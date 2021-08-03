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
            TerapiaPeriodo terapiaPeriodo = _mapper.Map<TerapiaPeriodo>(terapiaPeriodoDto);
            await _terapiaPeriodoService.AddTerapiaPeriodo(terapiaPeriodo);
            var response = new ApiResponse<bool>(true);

            return Ok(response);
        }
        [HttpGet("GetTerapiasPeriodos")]
        public IActionResult GetTerapiasPeriodos()
        {
            var list = _terapiaPeriodoService.GetTerapiasPeriodos();
            var listDto = _mapper.Map<IEnumerable<TerapiaPeriodoDto>>(list);
            var response = new ApiResponse<IEnumerable<TerapiaPeriodoDto>>(listDto);

            return Ok(response);
        }
        [HttpGet("GetTerapiaPeriodoByIds")]
        public async Task<IActionResult> GetTerapiaPeriodoByIds(int idTerapia, int idPeriodo)
        {
            var entity = await _terapiaPeriodoService.GetTerapiaPeriodoByIds(idTerapia, idPeriodo);
            var entityDto = _mapper.Map<TerapiaPeriodoDto>(entity);
            var response = new ApiResponse<TerapiaPeriodoDto>(entityDto);

            return Ok(response);
        }
    }
}
