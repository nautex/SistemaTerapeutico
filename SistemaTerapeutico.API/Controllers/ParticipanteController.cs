using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SistemaTerapeutico.API.Response;
using SistemaTerapeutico.Core.DTOs;
using SistemaTerapeutico.Core.Entities;
using SistemaTerapeutico.Core.Interfaces;
using SistemaTerapeutico.Core.Services;
using SistemaTerapeutico.Core.Views;
using SistemaTerapeutico.Infrastucture.Repositorios;

namespace SistemaTerapeutico.API.Controllers
{
    [Route("[controller]")]
    public class ParticipanteController : Controller
    {
        private readonly IParticipanteService _participanteService;
        private readonly IMapper _mapper;
        public ParticipanteController(IParticipanteService participanteService, IMapper mapper)
        {
            _participanteService = participanteService;
            _mapper = mapper;
        }
        [HttpPost("PostParticipante")]
        public async Task<IActionResult> PostParticipante(ParticipanteDto participanteDto)
        {
            Participante lParticipante = _mapper.Map<Participante>(participanteDto);
            await _participanteService.AddParticipante(lParticipante);
            var Response = new ApiResponse<bool>(true);

            return Ok(Response);
        }
        [HttpGet("GetParticipanteById")]
        public async Task<IActionResult> GetParticipanteById(int idParticipante)
        {
            var entity = await _participanteService.GetParticipanteById(idParticipante);
            var response = new ApiResponse<ParticipanteDto>(entity, _mapper);

            return Ok(response);
        }
        [HttpGet("GetsParticipantesResumenView")]
        public IActionResult GetsParticipantesResumenView()
        {
            var list = _participanteService.GetsParticipantesResumenView();
            var response = new ApiResponse<IEnumerable<ParticipanteResumenViewDto>>(list, _mapper);

            return Ok(response);
        }
        [HttpGet("GetsParticipantesResumenViewByMemberOrRelative")]
        public IActionResult GetsParticipantesResumenViewByMemberOrRelative(string member, string relative)
        {
            var list = _participanteService.GetsParticipantesResumenViewByMemberOrRelative(member, relative);
            var response = new ApiResponse<IEnumerable<ParticipanteResumenViewDto>>(list, _mapper);

            return Ok(response);
        }
        [HttpGet("GetsParticipanteAlergiaViewById")]
        public async Task<IActionResult> GetsParticipanteAlergiaViewById(int idParticipante)
        {
            var list = await _participanteService.GetsParticipanteAlergiaViewById(idParticipante);
            var response = new ApiResponse<IEnumerable<ParticipanteAlergiaViewDto>>(list, _mapper);

            return Ok(response);
        }
        [HttpGet("GetsParticipantePersonaAutorizadaViewById")]
        public async Task<IActionResult> GetsParticipantePersonaAutorizadaViewById(int idParticipante)
        {
            var list = await _participanteService.GetsParticipantePersonaAutorizadaViewById(idParticipante);
            var response = new ApiResponse<IEnumerable<ParticipantePersonaAutorizadaViewDto>>(list, _mapper);

            return Ok(response);
        }
        [HttpGet("GetParticipanteViewById")]
        public async Task<IActionResult> GetParticipanteViewById(int idParticipante)
        {
            var list = await _participanteService.GetParticipanteViewById(idParticipante);
            var response = new ApiResponse<ParticipanteViewDto>(list, _mapper);

            return Ok(response);
        }

        [HttpDelete("DeleteParticipanteAlergia")]
        public async Task<IActionResult> DeleteParticipanteAlergia(int idParticipante, int numero)
        {
            await _participanteService.DeleteParticipanteAlergia(idParticipante, numero);
            var response = new ApiResponse<bool>(true);

            return Ok(response);
        }
        [HttpDelete("DeleteParticipantePersonaAutorizada")]
        public async Task<IActionResult> DeleteParticipantePersonaAutorizada(int idParticipante, int numero)
        {
            await _participanteService.DeleteParticipantePersonaAutorizada(idParticipante, numero);
            var response = new ApiResponse<bool>(true);

            return Ok(response);
        }
        [HttpPost("AddUpdateParticipanteWithDetails")]
        public async Task<IActionResult> AddUpdateParticipanteWithDetails([FromBody] ParticipanteDto participanteDto)
        {
            Participante participante = _mapper.Map<Participante>(participanteDto);
            int idParticipante = await _participanteService.AddUpdateParticipanteWithDetails(participante);
            var Response = new ApiResponse<int>(idParticipante);

            return Ok(Response);
        }
    }
}
