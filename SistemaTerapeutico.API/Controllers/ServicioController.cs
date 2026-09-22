using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SistemaTerapeutico.API.Response;
using SistemaTerapeutico.Core.DTOs;
using SistemaTerapeutico.Core.Interfaces;
using SistemaTerapeutico.Infrastucture.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SistemaTerapeutico.API.Controllers
{
    [Route("[controller]")]
    public class ServicioController : Controller
    {
        private readonly ServicioService _servicioService;
        private readonly IMapper _mapper;
        public ServicioController(ServicioService servicioService, IMapper mapper)
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
        [HttpGet("GetConceptoCobroView")]
        public async Task<IActionResult> GetConceptoCobroView(int idConceptoCobro)
        {
            var list = await _servicioService.GetConceptoCobroView(idConceptoCobro);
            var response = new ApiResponse<ConceptoCobroViewDto>(list, _mapper);

            return Ok(response);
        }
        [HttpGet("GetsListConceptoCobro")]
        public IActionResult GetsListConceptoCobro()
        {
            var list = _servicioService.GetsListConceptoCobro();
            var response = new ApiResponse<IEnumerable<ListaDto>>(list, _mapper);

            return Ok(response);
        }
        [HttpGet("GetsConceptoCobroView")]
        public IActionResult GetsConceptoCobroView(int idServicio, int idFilial, int idTipo, int sesionesMes, int idEstado)
        {
            var list = _servicioService.GetsConceptoCobroView(idServicio, idFilial, idTipo, sesionesMes, idEstado);
            var response = new ApiResponse<IEnumerable<ConceptoCobroViewDto>>(list, _mapper);

            return Ok(response);
        }
        [HttpPost("AnnulConceptoCobro")]
        public async Task<IActionResult> AnnulConceptoCobro(int idConceptoCobro)
        {
            await _servicioService.AnnulConceptoCobro(idConceptoCobro);
            var response = new ApiResponse<bool>(true);

            return Ok(response);
        }
        [HttpPost("ActiveConceptoCobro")]
        public async Task<IActionResult> ActiveConceptoCobro(int idConceptoCobro)
        {
            await _servicioService.ActiveConceptoCobro(idConceptoCobro);
            var response = new ApiResponse<bool>(true);

            return Ok(response);
        }
        [HttpPost("AddUpdateConceptoCobro")]
        public async Task<IActionResult> AddUpdateConceptoCobro([FromBody] ConceptoCobroViewDto conceptoCobroViewDto)
        {
            int id = await _servicioService.AddUpdateConceptoCobro(conceptoCobroViewDto);
            var Response = new ApiResponse<int>(id);

            return Ok(Response);
        }
    }
}
