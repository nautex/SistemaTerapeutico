using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Renci.SshNet.Security.Cryptography.Ciphers.Modes;
using SistemaTerapeutico.API.Response;
using SistemaTerapeutico.Core.DTOs;
using SistemaTerapeutico.Core.Interfaces;
using SistemaTerapeutico.Core.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SistemaTerapeutico.API.Controllers
{
    [Route("[controller]")]
    public class ModeloController : Controller
    {
        private readonly IModeloService _modeloService;
        private readonly IMapper _mapper;
        public ModeloController(IModeloService moduloService, IMapper mapper)
        {
            _modeloService = moduloService;
            _mapper = mapper;
        }
        [HttpGet("GetsAreaObjetivoCriterioView")]
        public IActionResult GetsAreaObjetivoCriterioView(
            int idModelo, string codigoModelo, string modelo
            , int idArea, string codigoArea, string area
            , int idDestreza, string codigoDestreza, string destreza
            , int idAreaObjetivo, int ordenObjetivo, string codigoObjetivo, string objetivo
            , int idAreaObjetivoCriterio, int valor, string descripcion, int orden)
        {
            var list = _modeloService.GetsAreaObjetivoCriterioView(
                idModelo, codigoModelo, modelo
                , idArea, codigoArea, area
                , idDestreza, codigoDestreza, destreza
                , idAreaObjetivo, ordenObjetivo, codigoObjetivo, objetivo
                , idAreaObjetivoCriterio, valor, descripcion, orden);
            var response = new ApiResponse<IEnumerable<AreaObjetivoCriterioViewDto>>(list, _mapper);

            return Ok(response);
        }
        [HttpGet("GetsListModelo")]
        public IActionResult GetsListModelo()
        {
            var list = _modeloService.GetsListModelo();
            var response = new ApiResponse<IEnumerable<ListaDto>>(list, _mapper);

            return Ok(response);
        }
        [HttpGet("GetsModelo")]
        public IActionResult GetsModelo()
        {
            var list = _modeloService.GetsModelo();
            var response = new ApiResponse<IEnumerable<ModeloDto>>(list, _mapper);

            return Ok(response);
        }
        [HttpGet("GetsListArea")]
        public IActionResult GetsListArea(int idModelo)
        {
            var list = _modeloService.GetsListArea(idModelo);
            var response = new ApiResponse<IEnumerable<ListaDto>>(list, _mapper);

            return Ok(response);
        }
        [HttpGet("GetsArea")]
        public IActionResult GetsArea(int idModelo)
        {
            var list = _modeloService.GetsArea(idModelo);
            var response = new ApiResponse<IEnumerable<AreaDto>>(list, _mapper);

            return Ok(response);
        }
        [HttpGet("GetsListObjetivo")]
        public IActionResult GetsListObjetivo(int idArea)
        {
            var list = _modeloService.GetsListObjetivo(idArea);
            var response = new ApiResponse<IEnumerable<ListaDto>>(list, _mapper);

            return Ok(response);
        }
        [HttpGet("GetsObjetivo")]
        public IActionResult GetsObjetivo(int idArea)
        {
            var list = _modeloService.GetsObjetivo(idArea);
            var response = new ApiResponse<IEnumerable<AreaObjetivoDto>>(list, _mapper);

            return Ok(response);
        }
        [HttpGet("GetsListCriterio")]
        public IActionResult GetsListCriterio(int idAreaObjetivo)
        {
            var list = _modeloService.GetsListCriterio(idAreaObjetivo);
            var response = new ApiResponse<IEnumerable<ListaDto>>(list, _mapper);

            return Ok(response);
        }
        [HttpGet("GetsCriterio")]
        public IActionResult GetsCriterio(int idAreaObjetivo)
        {
            var list = _modeloService.GetsCriterio(idAreaObjetivo);
            var response = new ApiResponse<IEnumerable<AreaObjetivoCriterioDto>>(list, _mapper);

            return Ok(response);
        }
        [HttpPost("AddUpdateModelo")]
        public async Task<IActionResult> AddUpdateModelo([FromBody] ModeloDto entityDto)
        {
            int id = await _modeloService.AddUpdateModelo(entityDto);
            var Response = new ApiResponse<int>(id);

            return Ok(Response);
        }
        [HttpPost("AddUpdateArea")]
        public async Task<IActionResult> AddUpdateArea([FromBody] AreaDto entityDto)
        {
            int id = await _modeloService.AddUpdateArea(entityDto);
            var Response = new ApiResponse<int>(id);

            return Ok(Response);
        }
        [HttpPost("AddUpdateAreaObjetivo")]
        public async Task<IActionResult> AddUpdateAreaObjetivo([FromBody] AreaObjetivoDto entityDto)
        {
            int id = await _modeloService.AddUpdateAreaObjetivo(entityDto);
            var Response = new ApiResponse<int>(id);

            return Ok(Response);
        }
        [HttpPost("AddUpdateAreaObjetivoCriterio")]
        public async Task<IActionResult> AddUpdateAreaObjetivoCriterio([FromBody] AreaObjetivoCriterioDto entityDto)
        {
            int id = await _modeloService.AddUpdateAreaObjetivoCriterio(entityDto);
            var Response = new ApiResponse<int>(id);

            return Ok(Response);
        }
    }
}
