using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SistemaTerapeutico.API.Response;
using SistemaTerapeutico.Core.DTOs;
using SistemaTerapeutico.Core.Entities;
using SistemaTerapeutico.Core.Interfaces;
using SistemaTerapeutico.Core.Services;

namespace SistemaTerapeutico.API.Controllers
{
    [Route("[controller]")]
    public class SesionController : Controller
    {
        private readonly ISesionService _sesionService;
        private readonly IMapper _mapper;
        public SesionController(ISesionService sesionService, IMapper mapper)
        {
            _sesionService = sesionService;
            _mapper = mapper;
        }
        [HttpPost("PostSesion")]
        public async Task<IActionResult> PostSesion(SesionDto sesionDto)
        {
            Sesion sesion = _mapper.Map<Sesion>(sesionDto);
            var response = new ApiResponse<int>(await _sesionService.AddSesion(sesion));

            return Ok(response);
        }
        [HttpGet("GetSesiones")]
        public IActionResult GetSesiones()
        {
            IEnumerable<Sesion> list = _sesionService.GetSesiones();
            var response = new ApiResponse<IEnumerable<SesionDto>>(list, _mapper);

            return Ok(response);
        }
        [HttpPost("UpdateSesion")]
        public IActionResult UpdateSesion([FromBody] SesionDto sesionDto)
        {
            Sesion entity = _mapper.Map<Sesion>(sesionDto);
            _sesionService.UpdateSesion(entity);
            var Response = new ApiResponse<bool>(true);

            return Ok(Response);
        }
        [HttpGet("GetSesionView")]
        public async Task<IActionResult> GetSesionView(int idSesion)
        {
            var list = await _sesionService.GetSesionView(idSesion);
            var response = new ApiResponse<SesionViewDto>(list, _mapper);

            return Ok(response);
        }
        [HttpGet("GetsSesionResumenView")]
        public IActionResult GetsSesionResumenView(int idTerapeuta, string participante, int idPeriodo, DateTime? fechaInicio, DateTime? fechaFin, int idEstado)
        {
            var list = _sesionService.GetsSesionResumenView(idTerapeuta, participante, idPeriodo, fechaInicio, fechaFin, idEstado);
            var response = new ApiResponse<IEnumerable<SesionResumenViewDto>>(list, _mapper);

            return Ok(response);
        }
        [HttpPost("AddUpdateSessionWithDetails")]
        public async Task<IActionResult> AddUpdateSessionWithDetails([FromBody] SesionViewDto sesionDto)
        {
            SesionViewDto sesion = _mapper.Map<SesionViewDto>(sesionDto);
            int idSesion = await _sesionService.AddUpdateSessionWithDetails(sesion);
            var Response = new ApiResponse<int>(idSesion);

            return Ok(Response);
        }
        [HttpGet("GetsSesionTerapeutaView")]
        public async Task<IActionResult> GetsSesionTerapeutaView(int idSesion)
        {
            var list = await _sesionService.GetsSesionTerapeutaView(idSesion);
            var response = new ApiResponse<IEnumerable<SesionTerapeutaViewDto>>(list, _mapper);

            return Ok(response);
        }
        [HttpDelete("DeleteSesionTerapeuta")]
        public async Task<IActionResult> DeleteSesionTerapeuta(int idSesion, int numero)
        {
            await _sesionService.DeleteSesionTerapeuta(idSesion, numero);
            var response = new ApiResponse<bool>(true);

            return Ok(response);
        }
        [HttpGet("GetsSesionCriterioView")]
        public async Task<IActionResult> GetsSesionCriterioView(int idSesion)
        {
            var list = await _sesionService.GetsSesionCriterioView(idSesion);
            var response = new ApiResponse<IEnumerable<SesionCriterioViewDto>>(list, _mapper);

            return Ok(response);
        }
        [HttpDelete("DeleteSesionCriterio")]
        public async Task<IActionResult> DeleteSesionCriterio(int idSesion, int numero)
        {
            await _sesionService.DeleteSesionCriterio(idSesion, numero);
            var response = new ApiResponse<bool>(true);

            return Ok(response);
        }
        [HttpPost("AnnulSesion")]
        public async Task<IActionResult> AnnulSesion(int idSesion)
        {
            await _sesionService.AnnulSesion(idSesion);
            var response = new ApiResponse<bool>(true);

            return Ok(response);
        }
        [HttpPost("ActiveSesion")]
        public async Task<IActionResult> ActiveSesion(int idSesion)
        {
            await _sesionService.ActiveSesion(idSesion);
            var response = new ApiResponse<bool>(true);

            return Ok(response);
        }
    }
}
