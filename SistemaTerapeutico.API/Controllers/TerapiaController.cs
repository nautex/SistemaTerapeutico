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
    public class TerapiaController : Controller
    {
        private readonly ITerapiaService _terapiaService;
        private readonly IMapper _mapper;
        public TerapiaController(ITerapiaService terapiaServices, IMapper mapper)
        {
            _terapiaService = terapiaServices;
            _mapper = mapper;
        }
        [HttpPost("PostTerapia")]
        public async Task<IActionResult> PostTerapia(TerapiaDto terapiaDto)
        {
            Terapia terapia = _mapper.Map<Terapia>(terapiaDto);
            var Response = new ApiResponse<int>(await _terapiaService.AddTerapia(terapia));

            return Ok(Response);
        }
        [HttpGet("GetTerapias")]
        public IActionResult GetTerapias()
        {
            var list = _terapiaService.GetTerapias();
            var response = new ApiResponse<IEnumerable<TerapiaDto>>(list, _mapper);

            return Ok(response);
        }
    }
}
