using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SistemaTerapeutico.API.Response;
using SistemaTerapeutico.Core.DTOs;
using SistemaTerapeutico.Core.Entities;
using SistemaTerapeutico.Core.Interfaces;
using SistemaTerapeutico.Core.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SistemaTerapeutico.API.Controllers
{
    [Route("[controller]")]
    public class PuntuacionController : Controller
    {
        private readonly IPuntuacionService _puntuacionService;
        private readonly IMapper _mapper;
        public PuntuacionController(IPuntuacionService puntuacionService, IMapper mapper)
        {
            _puntuacionService = puntuacionService;
            _mapper = mapper;
        }
        [HttpPost("PostPuntuacionGrupo")]
        public async Task<IActionResult> PostPuntuacionGrupo(PuntuacionGrupoDto sesionDto)
        {
            PuntuacionGrupo sesion = _mapper.Map<PuntuacionGrupo>(sesionDto);
            var response = new ApiResponse<int>(await _puntuacionService.AddPuntuacionGrupo(sesion));

            return Ok(response);
        }
        [HttpGet("GetsPuntuacionGrupo")]
        public IActionResult GetPuntuacionGrupoes()
        {
            IEnumerable<PuntuacionGrupo> list = _puntuacionService.GetsPuntuacionGrupo();
            var response = new ApiResponse<IEnumerable<PuntuacionGrupoDto>>(list, _mapper);

            return Ok(response);
        }
        [HttpPost("UpdatePuntuacionGrupo")]
        public IActionResult UpdatePuntuacionGrupo([FromBody] PuntuacionGrupoDto sesionDto)
        {
            PuntuacionGrupo entity = _mapper.Map<PuntuacionGrupo>(sesionDto);
            _puntuacionService.UpdatePuntuacionGrupo(entity);
            var Response = new ApiResponse<bool>(true);

            return Ok(Response);
        }
    }
}
