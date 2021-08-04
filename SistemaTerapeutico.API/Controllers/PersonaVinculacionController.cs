using System.Collections.Generic;
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
    public class PersonaVinculacionController : Controller
    {
        private readonly IPersonaVinculacionService _personaVinculacionService;
        private readonly IMapper _mapper;
        public PersonaVinculacionController(IPersonaVinculacionService personaVinculacionService, IMapper mapper)
        {
            _personaVinculacionService = personaVinculacionService;
            _mapper = mapper;
        }
        [HttpPost("PostPersonaVinculacion")]
        public async Task<IActionResult> PostPersonaVinculacion(PersonaVinculacionDto personaVinculacionDto)
        {
            PersonaVinculacion personaVinculacion = _mapper.Map<PersonaVinculacion>(personaVinculacionDto);
            await _personaVinculacionService.AddPersonaVinculacion(personaVinculacion);
            var Response = new ApiResponse<bool>(true);

            return Ok(Response);
        }
        [HttpGet("GetPersonasVinculacionesByIdPersona")]
        public async Task<IActionResult> GetPersonasVinculacionesByIdPersona(int idPersona)
        {
            var list = await _personaVinculacionService.GetPersonasVinculacionesByIdPersona(idPersona);
            var response = new ApiResponse<IEnumerable<PersonaVinculacionDto>>(list, _mapper);

            return Ok(response);
        }
    }
}
