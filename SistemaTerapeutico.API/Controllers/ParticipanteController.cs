using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SistemaTerapeutico.API.Response;
using SistemaTerapeutico.Core.DTOs;
using SistemaTerapeutico.Core.Entities;
using SistemaTerapeutico.Core.Interfaces;

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
    }
}
