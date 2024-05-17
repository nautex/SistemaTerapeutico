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
    public class TerapiaController : Controller
    {
        private readonly ITerapiaService _terapiaService;
        private readonly IMapper _mapper;
        public TerapiaController(ITerapiaService terapiaServices, IMapper mapper)
        {
            _terapiaService = terapiaServices;
            _mapper = mapper;
        }
        [HttpPost("PostTerapia")]
        public async Task<IActionResult> PostTerapia(TerapiaViewDto terapiaDto)
        {
            Terapia terapia = _mapper.Map<Terapia>(terapiaDto);
            var Response = new ApiResponse<int>(await _terapiaService.AddTerapia(terapia));

            return Ok(Response);
        }
        [HttpGet("GetTerapias")]
        public IActionResult GetTerapias()
        {
            var list = _terapiaService.GetTerapias();
            var response = new ApiResponse<IEnumerable<TerapiaDto>>(list, _mapper);

            return Ok(response);
        }
        [HttpGet("GetsTerapiaResumenViewAll")]
        public IActionResult GetsTerapiaResumenViewAll()
        {
            var list = _terapiaService.GetsTerapiaResumenViewAll();
            var response = new ApiResponse<IEnumerable<TerapiaResumenViewDto>>(list, _mapper);

            return Ok(response);
        }
        [HttpGet("GetTerapiaView")]
        public async Task<IActionResult> GetTerapiaView(int idTerapia)
        {
            var list = await _terapiaService.GetTerapiaView(idTerapia);
            var response = new ApiResponse<TerapiaViewDto>(list, _mapper);

            return Ok(response);
        }
        [HttpGet("GetsTerapiaResumenViewByLocalOrMemberOrTherapist")]
        public IActionResult GetsTerapiaResumenViewByLocalOrMemberOrTherapist(string local, string member, string therapist)
        {
            var list = _terapiaService.GetsTerapiaResumenViewByLocalOrMemberOrTherapist(local, member, therapist);
            var response = new ApiResponse<IEnumerable<TerapiaResumenViewDto>>(list, _mapper);

            return Ok(response);
        }
        [HttpGet("GetsTerapiaHorarioView")]
        public async Task<IActionResult> GetsTerapiaHorarioView(int idTerapia)
        {
            var list = await _terapiaService.GetsTerapiaHorarioView(idTerapia);
            var response = new ApiResponse<IEnumerable<TerapiaHorarioViewDto>>(list, _mapper);

            return Ok(response);
        }
        [HttpGet("GetsTerapiaTerapeutaView")]
        public async Task<IActionResult> GetsTerapiaTerapeutaView(int idTerapia)
        {
            var list = await _terapiaService.GetsTerapiaTerapeutaView(idTerapia);
            var response = new ApiResponse<IEnumerable<TerapiaTerapeutaViewDto>>(list, _mapper);

            return Ok(response);
        }
        [HttpGet("GetsTerapiaParticipanteView")]
        public async Task<IActionResult> GetsTerapiaParticipanteView(int idTerapia)
        {
            var list = await _terapiaService.GetsTerapiaParticipanteView(idTerapia);
            var response = new ApiResponse<IEnumerable<TerapiaParticipanteViewDto>>(list, _mapper);

            return Ok(response);
        }
        [HttpDelete("DeleteTerapiaHorario")]
        public async Task<IActionResult> DeleteTerapiaHorario(int idTerapia, int numero)
        {
            await _terapiaService.DeleteTerapiaHorario(idTerapia, numero);
            var response = new ApiResponse<bool>(true);

            return Ok(response);
        }
        [HttpDelete("DeleteTerapiaTerapeuta")]
        public async Task<IActionResult> DeleteTerapiaTerapeuta(int idTerapia, int numero)
        {
            await _terapiaService.DeleteTerapiaTerapeuta(idTerapia, numero);
            var response = new ApiResponse<bool>(true);

            return Ok(response);
        }
        [HttpDelete("DeteleTerapiaParticipante")]
        public async Task<IActionResult> DeteleTerapiaParticipante(int idTerapia, int numero)
        {
            await _terapiaService.DeteleTerapiaParticipante(idTerapia, numero);
            var response = new ApiResponse<bool>(true);

            return Ok(response);
        }
        [HttpPost("AddUpdateIndividualTherapyWithDetails")]
        public async Task<IActionResult> AddUpdateIndividualTherapyWithDetails([FromBody] TerapiaDto terapiaDto)
        {
            TerapiaDto terapia = _mapper.Map<TerapiaDto>(terapiaDto);
            int idTerapia = await _terapiaService.AddUpdateIndividualTherapyWithDetails(terapia);
            var Response = new ApiResponse<int>(idTerapia);

            return Ok(Response);
        }
        [HttpGet("GetTerapiaParticipanteByIds")]
        public async Task<IActionResult> GetTerapiaParticipanteByIds(int idTerapia, int numero)
        {
            var list = await _terapiaService.GetTerapiaParticipanteByIds(idTerapia, numero);
            var response = new ApiResponse<TerapiaParticipanteViewDto>(list, _mapper);

            return Ok(response);
        }
    }
}
