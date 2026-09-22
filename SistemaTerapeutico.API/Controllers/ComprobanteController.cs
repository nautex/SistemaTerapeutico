using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SistemaTerapeutico.API.Response;
using SistemaTerapeutico.Core.DTOs;
using SistemaTerapeutico.Core.Entities;
using SistemaTerapeutico.Core.Interfaces;
using SistemaTerapeutico.Infrastucture.Services;
using SistemaTerapeutico.Core.Views;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SistemaTerapeutico.API.Controllers
{
    [Route("[controller]")]
    public class ComprobanteController : Controller
    {
        private readonly ComprobanteService _comprobanteService;
        private readonly IMapper _mapper;
        public ComprobanteController(ComprobanteService comprobanteServices, IMapper mapper)
        {
            _comprobanteService = comprobanteServices;
            _mapper = mapper;
        }
        [HttpPost("AddComprobante")]
        public async Task<IActionResult> AddComprobante(ComprobanteViewDto comprobanteDto)
        {
            Comprobante comprobante = _mapper.Map<Comprobante>(comprobanteDto);
            var Response = new ApiResponse<int>(await _comprobanteService.AddComprobante(comprobante));

            return Ok(Response);
        }
        [HttpGet("GetsComprobante")]
        public IActionResult GetsComprobante()
        {
            var list = _comprobanteService.GetsComprobante();
            var response = new ApiResponse<IEnumerable<ComprobanteDto>>(list, _mapper);

            return Ok(response);
        }
        [HttpGet("GetComprobanteView")]
        public async Task<IActionResult> GetComprobanteView(int idComprobante)
        {
            var list = await _comprobanteService.GetComprobanteView(idComprobante);
            var response = new ApiResponse<ComprobanteViewDto>(list, _mapper);

            return Ok(response);
        }
        [HttpGet("GetsComprobanteResumenViewFilter")]
        public IActionResult GetsComprobanteResumenViewFilter(DateTime? fechaInicio, DateTime? fechaFin, int idTipo, string serie, string numero, string dniCobrador, string cobrador, string dniPagador, string pagador, int idEstadoPago, int idEstado)
        {
            var list = _comprobanteService.GetsComprobanteResumenViewFilter(fechaInicio, fechaFin, idTipo, serie, numero, dniCobrador, cobrador, dniPagador, pagador, idEstadoPago, idEstado);
            var response = new ApiResponse<IEnumerable<ComprobanteResumenViewDto>>(list, _mapper);

            return Ok(response);
        }
        [HttpPost("AnnulComprobante")]
        public async Task<IActionResult> AnnulComprobante(int idComprobante)
        {
            await _comprobanteService.AnnulComprobante(idComprobante);
            var response = new ApiResponse<bool>(true);

            return Ok(response);
        }
        [HttpPost("ActiveComprobante")]
        public async Task<IActionResult> ActiveComprobante(int idComprobante)
        {
            await _comprobanteService.ActiveComprobante(idComprobante);
            var response = new ApiResponse<bool>(true);

            return Ok(response);
        }

        [HttpPost("AddUpdateComprobanteWithDetails")]
        public async Task<IActionResult> AddUpdateComprobanteWithDetails([FromBody] ComprobanteDto comprobanteDto)
        {
            ComprobanteDto comprobante = _mapper.Map<ComprobanteDto>(comprobanteDto);
            int idComprobante = await _comprobanteService.AddUpdateComprobanteWithDetails(comprobante);
            var Response = new ApiResponse<int>(idComprobante);

            return Ok(Response);
        }
    }
}
