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

        [HttpGet("GetSesionesCriterios")]
        public IActionResult GetSesionesCriterios()
        {
            var list = _sesionCriterioService.GetSesionesCriterios();
            var response = new ApiResponse<IEnumerable<SesionCriterio>>(list);

            return Ok(response);
        }
        [HttpPost("PostSesionCriterio")]
        public async Task<IActionResult> PostSesionCriterio(SesionCriterioDto sesionCriterioDto)
        {
            SesionCriterio sesionCriterio = new SesionCriterio(sesionCriterioDto.UsuarioRegistro)
            {
                IdSesion = sesionCriterioDto.IdSesion,
                IdObjetivoCriterio = sesionCriterioDto.IdObjetivoCriterio
            };
            var response = new ApiResponse<int>(await _sesionCriterioService.AddSesionCriterio(sesionCriterio));
            return Ok(response);
        }
        [HttpGet("GetSesionesByIdSesion")]
        public async Task<IActionResult> GetSesionesByIdSesion(int idSesion)
        {
            var entity = await _sesionCriterioService.GetSesionCriterioById(idSesion);
            var response = new ApiResponse<SesionCriterio>(entity);

            return Ok(response);
        }
    }
}
