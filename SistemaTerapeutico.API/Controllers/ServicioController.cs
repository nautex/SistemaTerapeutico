using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SistemaTerapeutico.API.Response;
using SistemaTerapeutico.Core.DTOs;
using SistemaTerapeutico.Core.Interfaces;
using SistemaTerapeutico.Core.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

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
        [HttpGet("GetTarifaView")]
        public async Task<IActionResult> GetTarifaView(int idTarifa)
        {
            var list = await _servicioService.GetTarifaView(idTarifa);
            var response = new ApiResponse<TarifaViewDto>(list, _mapper);

            return Ok(response);
        }
        [HttpGet("GetsListTarifa")]
        public IActionResult GetsListTarifa()
        {
            var list = _servicioService.GetsListTarifa();
            var response = new ApiResponse<IEnumerable<ListaDto>>(list, _mapper);

            return Ok(response);
        }
        [HttpGet("GetsTarifaView")]
        public IActionResult GetsTarifaView(int idServicio, int idLocal, int idTipo, int sesionesMes, int idEstado)
        {
            var list = _servicioService.GetsTarifaView(idServicio, idLocal, idTipo, sesionesMes, idEstado);
            var response = new ApiResponse<IEnumerable<TarifaViewDto>>(list, _mapper);

            return Ok(response);
        }
        [HttpPost("AnnulTarifa")]
        public async Task<IActionResult> AnnulTarifa(int idTarifa)
        {
            await _servicioService.AnnulTarifa(idTarifa);
            var response = new ApiResponse<bool>(true);

            return Ok(response);
        }
        [HttpPost("ActiveTarifa")]
        public async Task<IActionResult> ActiveTarifa(int idTarifa)
        {
            await _servicioService.ActiveTarifa(idTarifa);
            var response = new ApiResponse<bool>(true);

            return Ok(response);
        }
        [HttpPost("AddUpdateTarifa")]
        public async Task<IActionResult> AddUpdateTarifa([FromBody] TarifaViewDto tarifaViewDto)
        {
            int id = await _servicioService.AddUpdateTarifa(tarifaViewDto);
            var Response = new ApiResponse<int>(id);

            return Ok(Response);
        }
    }
}
