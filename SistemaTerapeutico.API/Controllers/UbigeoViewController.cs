using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SistemaTerapeutico.API.Response;
using SistemaTerapeutico.Core.DTOs;
using SistemaTerapeutico.Core.Interfaces;

namespace SistemaTerapeutico.API.Controllers
{
    [Route("[controller]")]
    public class UbigeoViewController : Controller
    {
        private readonly IUbigeoViewService _ubigeoViewService;
        private readonly IMapper _mapper;
        public UbigeoViewController(IUbigeoViewService ubigeoViewService, IMapper mapper)
        {
            _ubigeoViewService = ubigeoViewService;
            _mapper = mapper;
        }
        [HttpGet("GetUbigeoViewById")]
        public IActionResult GetUbigeoViewById(int idUbigeo)
        {
            var entity = _ubigeoViewService.GetUbigeoViewById(idUbigeo);
            var response = new ApiResponse<UbigeoViewDto>(entity, _mapper);

            return Ok(response);
        }
        [HttpGet("GetPaises")]
        public async Task<IActionResult> GetPaises()
        {
            var list = await _ubigeoViewService.GetPaises();
            var response = new ApiResponse<IEnumerable<ListaDto>>(list, _mapper);

            return Ok(response);
        }
        [HttpGet("GetDepartamentosByIdPais")]
        public async Task<IActionResult> GetDepartamentosByIdPais(int idPais)
        {
            var list = await _ubigeoViewService.GetDepartamentosByIdPais(idPais);
            var response = new ApiResponse<IEnumerable<ListaDto>>(list, _mapper);

            return Ok(response);
        }
        [HttpGet("GetProvinciasByIdDepartamento")]
        public async Task<IActionResult> GetProvinciasByIdDepartamento(int idDepartamento)
        {
            var list = await _ubigeoViewService.GetProvinciasByIdDepartamento(idDepartamento);
            var response = new ApiResponse<IEnumerable<ListaDto>>(list, _mapper);

            return Ok(response);
        }
        [HttpGet("GetUbigeosByIdProvincia")]
        public async Task<IActionResult> GetUbigeosByIdProvincia(int idProvincia)
        {
            var list = await _ubigeoViewService.GetUbigeosByIdProvincia(idProvincia);
            var response = new ApiResponse<IEnumerable<ListaDto>>(list, _mapper);

            return Ok(response);
        }
    }
}
