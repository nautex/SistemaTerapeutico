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
    public class TerapiaPlanController : Controller
    {
        private readonly ITerapiaPlanService _terapiaPlanService;
        private readonly IMapper _mapper;
        public TerapiaPlanController(ITerapiaPlanService terapiaPlanService, IMapper mapper)
        {
            _terapiaPlanService = terapiaPlanService;
            _mapper = mapper;
        }
        [HttpPost("PostTerapiaPlan")]
        public async Task<IActionResult> PostTerapiaPlan(TerapiaPlanViewDto terapiaPlanDto)
        {
            TerapiaPlan terapiaPlan = _mapper.Map<TerapiaPlan>(terapiaPlanDto);
            var Response = new ApiResponse<int>(await _terapiaPlanService.AddTerapiaPlan(terapiaPlan));

            return Ok(Response);
        }
        [HttpGet("GetsTerapiaPlan")]
        public IActionResult GetsTerapiaPlan()
        {
            var list = _terapiaPlanService.GetsTerapiaPlan();
            var response = new ApiResponse<IEnumerable<TerapiaPlanDto>>(list, _mapper);

            return Ok(response);
        }
        [HttpGet("GetsTerapiaPlanResumenViewAll")]
        public IActionResult GetsTerapiaPlanResumenViewAll()
        {
            var list = _terapiaPlanService.GetsTerapiaPlanResumenViewAll();
            var response = new ApiResponse<IEnumerable<TerapiaPlanResumenViewDto>>(list, _mapper);

            return Ok(response);
        }
        [HttpGet("GetTerapiaPlanView")]
        public async Task<IActionResult> GetTerapiaPlanView(int idTerapiaPlan)
        {
            var list = await _terapiaPlanService.GetTerapiaPlanView(idTerapiaPlan);
            var response = new ApiResponse<TerapiaPlanViewDto>(list, _mapper);

            return Ok(response);
        }
        [HttpGet("GetsTerapiaPlanResumenView")]
        public IActionResult GetsTerapiaPlanResumenView(int idLocal, string member, string therapist, int idEstadoVigencia, int idEstado)
        {
            var list = _terapiaPlanService.GetsTerapiaPlanResumenView(idLocal, member, therapist, idEstadoVigencia, idEstado);
            var response = new ApiResponse<IEnumerable<TerapiaPlanResumenViewDto>>(list, _mapper);

            return Ok(response);
        }
        [HttpGet("GetsTerapiaPlanAreaView")]
        public async Task<IActionResult> GetsTerapiaPlanAreaView(int idTerapiaPlan)
        {
            var list = await _terapiaPlanService.GetsTerapiaPlanAreaView(idTerapiaPlan);
            var response = new ApiResponse<IEnumerable<TerapiaPlanAreaViewDto>>(list, _mapper);

            return Ok(response);
        }
        [HttpGet("GetsArea")]
        public IActionResult GetsArea(int idTerapia)
        {
            var list = _terapiaPlanService.GetsArea(idTerapia);
            var response = new ApiResponse<IEnumerable<AreaDto>>(list, _mapper);

            return Ok(response);
        }
        [HttpDelete("DeleteTerapiaPlanArea")]
        public async Task<IActionResult> DeleteTerapiaPlanArea(int idTerapiaPlan, int numero)
        {
            await _terapiaPlanService.DeleteTerapiaPlanArea(idTerapiaPlan, numero);
            var response = new ApiResponse<bool>(true);

            return Ok(response);
        }
        [HttpPost("AddUpdateTerapiaPlanWithDetails")]
        public async Task<IActionResult> AddUpdateTerapiaPlanWithDetails([FromBody] TerapiaPlanDto terapiaPlanDto)
        {
            TerapiaPlanDto terapiaPlan = _mapper.Map<TerapiaPlanDto>(terapiaPlanDto);
            int idTerapiaPlan = await _terapiaPlanService.AddUpdateTerapiaPlanWithDetails(terapiaPlan);
            var Response = new ApiResponse<int>(idTerapiaPlan);

            return Ok(Response);
        }
        [HttpPost("AnnulTerapiaPlan")]
        public async Task<IActionResult> AnnulTerapiaPlan(int idTerapiaPlan)
        {
            await _terapiaPlanService.AnnulTerapiaPlan(idTerapiaPlan);
            var response = new ApiResponse<bool>(true);

            return Ok(response);
        }
        [HttpPost("ActiveTerapiaPlan")]
        public async Task<IActionResult> ActiveTerapiaPlan(int idTerapiaPlan)
        {
            await _terapiaPlanService.ActiveTerapiaPlan(idTerapiaPlan);
            var response = new ApiResponse<bool>(true);

            return Ok(response);
        }
    }
}
