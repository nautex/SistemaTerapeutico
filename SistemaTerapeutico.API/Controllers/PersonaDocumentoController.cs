using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SistemaTerapeutico.API.Response;
using SistemaTerapeutico.Core.DTOs;
using SistemaTerapeutico.Core.Entities;
using SistemaTerapeutico.Core.Interfaces;
using SistemaTerapeutico.Core.QueryFilters;

namespace SistemaTerapeutico.API.Controllers
{
    [Route("[controller]")]
    public class PersonaDocumentoController : Controller
    {
        private readonly IPersonaDocumentoService _personaDocumentoService;
        private readonly IMapper _mapper;
        public PersonaDocumentoController(IPersonaDocumentoService personaDocumentoService, IMapper mapper)
        {
            _personaDocumentoService = personaDocumentoService;
            _mapper = mapper;
        }
        [HttpGet("GetPersonaDocumentoByTipoYNumero")]
        public async Task<IActionResult> GetPersonaDocumentoByTipoYNumero(PersonaDocumentoQueryFilter queryFilter)
        {
            var entity = await _personaDocumentoService.GetPersonasDocumentosByTipoYNumero(queryFilter.IdTipoDocumento, queryFilter.NumeroDocumento);
            var response = new ApiResponse<IEnumerable<PersonaDocumentoDto>>(entity, _mapper);

            return Ok(response);
        }
        [HttpPost("PostPersonaDocumento")]
        public async Task<IActionResult> PostPersonaDocumento(PersonaDocumentoDto personaDocumentoDto)
        {
            PersonaDocumento personaDocumento = _mapper.Map<PersonaDocumento>(personaDocumentoDto);
            await _personaDocumentoService.AddPersonaDocumento(personaDocumento);
            var Response = new ApiResponse<bool>(true);

            return Ok(Response);
        }
        [HttpGet("GetPersonasDocumentosByIdPersona")]
        public async Task<IActionResult> GetPersonasDocumentosByIdPersona(int idPersona)
        {
            var list = await _personaDocumentoService.GetPersonasDocumentosByIdPersona(idPersona);
            var response = new ApiResponse<IEnumerable<PersonaDocumentoDto>>(list, _mapper);

            return Ok(response);
        }
    }
}
