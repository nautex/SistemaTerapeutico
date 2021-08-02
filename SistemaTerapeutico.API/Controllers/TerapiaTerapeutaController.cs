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
    public class TerapiaTerapeutaController : Controller
    {
        private readonly ITerapiaTerapeutaService _terapiaTerapeutaService;
        private readonly IMapper _mapper;
        public TerapiaTerapeutaController(ITerapiaTerapeutaService terapiaTerapeutaService, IMapper mapper)
        {
            _terapiaTerapeutaService = terapiaTerapeutaService;
            _mapper = mapper;
        }
        [HttpPost("PostTerapiaTerapeuta")]
        public async Task<IActionResult> PostTerapiaTerapeuta(TerapiaTerapeutaDto xterapiaTerapeutaDto)
        {
            TerapiaTerapeuta terapiaTerapeuta = new TerapiaTerapeuta(xterapiaTerapeutaDto.Usuario)
            {
                Id = xterapiaTerapeutaDto.IdTerapia,
                IdTwo = xterapiaTerapeutaDto.IdTerapeuta,
                IdTipoCargo = xterapiaTerapeutaDto.IdTipoCargo,
                FechaInicio = xterapiaTerapeutaDto.FechaInicio,
                FechaFin = xterapiaTerapeutaDto.FechaFin
            };
            await _terapiaTerapeutaService.AddTerapiaTerapeuta(terapiaTerapeuta);
            var response = new ApiResponse<bool>(true);

            return Ok(response);
        }
    }
}
