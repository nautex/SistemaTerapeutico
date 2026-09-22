using AutoMapper;
using Microsoft.AspNetCore.Mvc;
//using Renci.SshNet.Security.Cryptography.Ciphers.Modes;
using SistemaTerapeutico.API.Response;
using SistemaTerapeutico.Core.DTOs;
using SistemaTerapeutico.Core.Interfaces;
using SistemaTerapeutico.Infrastucture.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SistemaTerapeutico.API.Controllers
{
    [Route("[controller]")]
    public class ModeloController : Controller
    {
        private readonly ModeloService _modeloService;
        private readonly IMapper _mapper;
        public ModeloController(ModeloService moduloService, IMapper mapper)
        {
            _modeloService = moduloService;
            _mapper = mapper;
        }
        [HttpGet("GetsAreaObjetivoCriterioResumenView")]
        public IActionResult GetsAreaObjetivoCriterioResumenView(
            int idModelo, string codigoModelo, string modelo
            , int idArea, string codigoArea, string area
            , int idDestreza, string codigoDestreza, string destreza
            , int idAreaObjetivo, string codigoObjetivo, string objetivo
            , int idAreaObjetivoCriterio, int valor, string descripcion, int orden)
        {
            var list = _modeloService.GetsAreaObjetivoCriterioResumenView(
                idModelo, codigoModelo, modelo
                , idArea, codigoArea, area
                , idDestreza, codigoDestreza, destreza
                , idAreaObjetivo, codigoObjetivo, objetivo
                , idAreaObjetivoCriterio, valor, descripcion, orden);
            var response = new ApiResponse<IEnumerable<AreaObjetivoCriterioResumenViewDto>>(list, _mapper);

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
        [HttpGet("GetArea")]
        public async Task<IActionResult> GetArea(int idArea)
        {
            var list = await _modeloService.GetArea(idArea);
            var response = new ApiResponse<AreaViewDto>(list, _mapper);

            return Ok(response);
        }
        [HttpGet("GetDestreza")]
        public async Task<IActionResult> GetDestreza(int idDestreza)
        {
            var list = await _modeloService.GetDestreza(idDestreza);
            var response = new ApiResponse<DestrezaDto>(list, _mapper);

            return Ok(response);
        }
        [HttpGet("GetsArea")]
        public IActionResult GetsArea(int idModelo)
        {
            var list = _modeloService.GetsArea(idModelo);
            var response = new ApiResponse<IEnumerable<AreaDto>>(list, _mapper);

            return Ok(response);
        }
        [HttpGet("GetsListAreaObjetivo")]
        public IActionResult GetsListAreaObjetivo(int idArea)
        {
            var list = _modeloService.GetsListAreaObjetivo(idArea);
            var response = new ApiResponse<IEnumerable<ListaDto>>(list, _mapper);

            return Ok(response);
        }
        [HttpGet("GetsAreaObjetivo")]
        public IActionResult GetsAreaObjetivo(int idArea)
        {
            var list = _modeloService.GetsAreaObjetivo(idArea);
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
        [HttpPost("AddUpdateDestreza")]
        public async Task<IActionResult> AddUpdateDestreza([FromBody] DestrezaDto entityDto)
        {
            int id = await _modeloService.AddUpdateDestreza(entityDto);
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
        [HttpGet("GetsListDestreza")]
        public IActionResult GetsListDestreza()
        {
            var list = _modeloService.GetsListDestreza();
            var response = new ApiResponse<IEnumerable<ListaDto>>(list, _mapper);

            return Ok(response);
        }
        [HttpGet("GetAreaObjetivo")]
        public async Task<IActionResult> GetAreaObjetivo(int idAreaObjetivo)
        {
            var list = await _modeloService.GetAreaObjetivo(idAreaObjetivo);
            var response = new ApiResponse<AreaObjetivoViewDto>(list, _mapper);

            return Ok(response);
        }
        [HttpGet("GetAreaObjetivoCriterio")]
        public async Task<IActionResult> GetAreaObjetivoCriterio(int idAreaObjetivoCriterio)
        {
            var list = await _modeloService.GetAreaObjetivoCriterio(idAreaObjetivoCriterio);
            var response = new ApiResponse<AreaObjetivoCriterioViewDto>(list, _mapper);

            return Ok(response);
        }
    }
}
