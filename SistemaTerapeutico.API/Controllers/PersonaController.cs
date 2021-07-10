using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SistemaTerapeutico.API.Response;
using SistemaTerapeutico.Core.DTOs;
using SistemaTerapeutico.Core.Entities;
using SistemaTerapeutico.Core.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SistemaTerapeutico.API.Controllers
{
    [Route("[controller]")]
    public class PersonaController : Controller
    {
        private readonly IPersonaService _personaService;
        private readonly IMapper _mapper;

        public PersonaController(IPersonaService personaService, IMapper mapper)
        {
            _personaService = personaService;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("get")]
        public async Task<IActionResult> GetPersonas()
        {
            var Personas = await _personaService.GetPersonas();
            var PersonasDto = _mapper.Map<IEnumerable<PersonaDto>>(Personas);
            var Response = new ApiResponse<IEnumerable<PersonaDto>>(PersonasDto);

            return Ok(Response);
        }

        [HttpGet("{pIdPersona}")]
        public async Task<IActionResult> GetPersonaById(int idPersona)
        {
            var Persona = await _personaService.GetPersonaById(idPersona);
            var PersonaDto = _mapper.Map<PersonaDto>(Persona);
            var Response = new ApiResponse<PersonaDto>(PersonaDto);

            return Ok(Response);
        }

        [HttpPost("get1")]
        public async Task<IActionResult> PostPersona([FromBody] PersonaDto personaDto)
        {
            Persona Persona = _mapper.Map<Persona>(personaDto);
            await _personaService.AddPersona(Persona);
            var Response = new ApiResponse<PersonaDto>(personaDto);

            return Ok(Response);
        }

        [HttpPost("get2")]
        public async Task<IActionResult> PostPersonaNaturalDatosCompletos([FromBody] PersonaNaturalDatosCompletosDto personaNaturalDatosCompletosDto)
        {
            int IdPersona = await _personaService.AddPersonaNaturalDatosCompletos(personaNaturalDatosCompletosDto);
            var Response = new ApiResponse<int>(IdPersona);

            return Ok(Response);
        }
    }
}
