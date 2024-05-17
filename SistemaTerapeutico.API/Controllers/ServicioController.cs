using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SistemaTerapeutico.API.Response;
using SistemaTerapeutico.Core.DTOs;
using SistemaTerapeutico.Core.Interfaces;
using SistemaTerapeutico.Core.Services;
using System.Collections.Generic;

namespace SistemaTerapeutico.API.Controllers
{
    [Route("[controller]")]
    public class ServicioController : Controller
    {
        private readonly IServicioService _servicioService;
        private readonly IMapper _mapper;
        public ServicioController(IServicioService servicioService, IMapper mapper)
        {
            _servicioService = servicioService;
            _mapper = mapper;
        }
        [HttpGet("GetsServicio")]
        public IActionResult GetsServicio()
        {
            var list = _servicioService.GetAll();
            var response = new ApiResponse<IEnumerable<ServicioDto>>(list, _mapper);

            return Ok(response);
        }
        [HttpGet("GetsListServicio")]
        public IActionResult GetsListServicio()
        {
            var list = _servicioService.GetsListServicio();
            var response = new ApiResponse<IEnumerable<ListaDto>>(list, _mapper);

            return Ok(response);
        }
        [HttpGet("GetsTarifa")]
        public IActionResult GetsTarifa()
        {
            var list = _servicioService.GetsTarifa();
            var response = new ApiResponse<IEnumerable<TarifaViewDto>>(list, _mapper);

            return Ok(response);
        }
        [HttpGet("GetsListTarifa")]
        public IActionResult GetsListTarifa()
        {
            var list = _servicioService.GetsListTarifa();
            var response = new ApiResponse<IEnumerable<ListaDto>>(list, _mapper);

            return Ok(response);
        }
        [HttpGet("GetsTarifaByIdServicioOrIdLocalOrSesionesMes")]
        public IActionResult GetsTarifaByIdServicioOrIdLocalOrSesionesMes(int idServicio, int idLocal, int idTipo, int sesionesMes)
        {
            var list = _servicioService.GetsTarifaByIdServicioOrIdLocalOrIdTipoOrSesionesMes(idServicio, idLocal, idTipo, sesionesMes);
            var response = new ApiResponse<IEnumerable<TarifaViewDto>>(list, _mapper);

            return Ok(response);
        }
    }
}
