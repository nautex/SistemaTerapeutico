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
        [HttpGet("GetsTerapiaResumenViewByIdLocalOrMemberOrTherapist")]
        public IActionResult GetsTerapiaResumenViewByIdLocalOrMemberOrTherapist(int idLocal, string member, string therapist, int idEstado)
        {
            var list = _terapiaService.GetsTerapiaResumenViewByIdLocalOrMemberOrTherapist(idLocal, member, therapist, idEstado);
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
        [HttpGet("GetsTerapiaHorarioViewByWeekDay")]
        public async Task<IActionResult> GetsTerapiaHorarioViewByWeekDay(int idTerapia, int weekDay)
        {
            var list = await _terapiaService.GetsTerapiaHorarioViewByWeekDay(idTerapia, weekDay);
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
        public async Task<IActionResult> GetsTerapiaParticipanteView(int idTerapia, int idEstado)
        {
            var list = await _terapiaService.GetsTerapiaParticipanteView(idTerapia, idEstado);
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
        [HttpPost("AddUpdateTherapyWithDetails")]
        public async Task<IActionResult> AddUpdateTherapyWithDetails([FromBody] TerapiaDto terapiaDto)
        {
            TerapiaDto terapia = _mapper.Map<TerapiaDto>(terapiaDto);
            int idTerapia = await _terapiaService.AddUpdateTherapyWithDetails(terapia);
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
        [HttpGet("GetsTerapiaParticipanteResumenView")]
        public IActionResult GetsTerapiaParticipanteResumenView(int idTipoTerapia, int idEstado)
        {
            var list = _terapiaService.GetsTerapiaParticipanteResumenView(idTipoTerapia, idEstado);
            var response = new ApiResponse<IEnumerable<TerapiaParticipanteResumenViewDto>>(list, _mapper);

            return Ok(response);
        }
        [HttpGet("GetsTerapiaPeriodoResumenView")]
        public IActionResult GetsTerapiaPeriodoResumenView(int idPeriodo, int idTipoTerapia, string participante, int idTerapeuta, string terapeuta, int idEstado)
        {
            var list = _terapiaService.GetsTerapiaPeriodoResumenView(idPeriodo, idTipoTerapia, participante, idTerapeuta, terapeuta, idEstado);
            var response = new ApiResponse<IEnumerable<TerapiaPeriodoResumenViewDto>>(list, _mapper);

            return Ok(response);
        }
        [HttpPost("AddTerapiaPeriodo")]
        public async Task<IActionResult> AddTerapiaPeriodo(int idPeriodo, int idTerapia, int numero, int idTarifa)
        {
            var Response = new ApiResponse<int>(await _terapiaService.AddTerapiaPeriodo(idPeriodo, idTerapia, numero, idTarifa));

            return Ok(Response);
        }
        [HttpPost("AnnulTerapiaPeriodo")]
        public async Task<IActionResult> AnnulTerapiaPeriodo(int idTerapiaPeriodo)
        {
            await _terapiaService.AnnulTerapiaPeriodo(idTerapiaPeriodo);
            var response = new ApiResponse<bool>(true);

            return Ok(response);
        }
        [HttpPost("ActiveTerapiaPeriodo")]
        public async Task<IActionResult> ActiveTerapiaPeriodo(int idTerapiaPeriodo)
        {
            await _terapiaService.ActiveTerapiaPeriodo(idTerapiaPeriodo);
            var response = new ApiResponse<bool>(true);

            return Ok(response);
        }
        [HttpPost("AnnulTerapia")]
        public async Task<IActionResult> AnnulTerapia(int idTerapia)
        {
            await _terapiaService.AnnulTerapia(idTerapia);
            var response = new ApiResponse<bool>(true);

            return Ok(response);
        }
        [HttpPost("ActiveTerapia")]
        public async Task<IActionResult> ActiveTerapia(int idTerapia)
        {
            await _terapiaService.ActiveTerapia(idTerapia);
            var response = new ApiResponse<bool>(true);

            return Ok(response);
        }
        [HttpGet("GetTerapiaPeriodoResumenView")]
        public async Task<IActionResult> GetTerapiaPeriodoResumenView(int idTerapiaPeriodo)
        {
            var list = await _terapiaService.GetTerapiaPeriodoResumenView(idTerapiaPeriodo);
            var response = new ApiResponse<TerapiaPeriodoResumenViewDto>(list, _mapper);

            return Ok(response);
        }
    }
}
