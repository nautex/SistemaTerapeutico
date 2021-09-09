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
    //[Authorize]
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

        [HttpGet("GetPersonas")]
        public IActionResult GetPersonas()
        {
            var list = _personaService.GetPersonas();
            var response = new ApiResponse<IEnumerable<PersonaDto>>(list, _mapper);

            return Ok(response);
        }

        [HttpGet("GetPersonaById")]
        public async Task<IActionResult> GetPersonaById(int idPersona)
        {
            var persona = await _personaService.GetPersonaById(idPersona);
            var response = new ApiResponse<PersonaDto>(persona, _mapper);

            return Ok(response);
        }
        //[HttpPost("PostPersonaNaturalDatosCompletos")]
        //public async Task<IActionResult> PostPersonaNaturalDatosCompletos([FromBody] PersonaNaturalDatosCompletosDto persona)
        //{
        //    PersonaResponseDto personaResponse = await _personaService.AddPersonaNaturalDatosCompletos(persona);
        //    var Response = new ApiResponse<PersonaResponseDto>(personaResponse);

        //    return Ok(Response);
        //}
        [HttpPost("PostPersonaNaturalUpdateWithDetails")]
        public async Task<IActionResult> PostPersonaNaturalUpdateWithDetails([FromBody] PersonaNaturalWDDto personaDto)
        {
            Persona persona = _mapper.Map<Persona>(personaDto);
            PersonaNatural personaNatural = _mapper.Map<PersonaNatural>(personaDto);
            //List<PersonaDireccion> personaDireccion = _mapper.Map<List<PersonaDireccion>>(personaDto.PersonaDireccion);
            //List<PersonaDocumento> personaDocumento = _mapper.Map<List<PersonaDocumento>>(personaDto.PersonaDocumento);
            //List<PersonaContacto> personaContacto = _mapper.Map<List<PersonaContacto>>(personaDto.PersonaContacto);
            //List<PersonaVinculacion> personaVinculacion = _mapper.Map<List<PersonaVinculacion>>(personaDto.PersonaVinculacion);
            persona.PersonaNatural = _mapper.Map<PersonaNatural>(personaDto);
            await _personaService.AddPersonaNaturalWithDetails(persona);
            var Response = new ApiResponse<bool>(true);

            return Ok(Response);
        }
        [HttpGet("GetPersonasByNombres")]
        public async Task<IActionResult> GetPersonasByNombres(string nombres)
        {
            var list = await _personaService.GetPersonasByNombre(nombres);
            var response = new ApiResponse<IEnumerable<PersonaDto>>(list, _mapper);

            return Ok(response);
        }
        [HttpPost("PostPersona")]
        public async Task<IActionResult> PostPersona(PersonaDto personaDto)
        {
            Persona persona = _mapper.Map<Persona>(personaDto);
            var response = new ApiResponse<int>(await _personaService.AddPersona(persona));

            return Ok(response);
        }
        [HttpGet("GetPersonasResumenView")]
        public IActionResult GetPersonasResumenView()
        {
            var list = _personaService.GetPersonasResumenView();
            var response = new ApiResponse<IEnumerable<PersonaResumenViewDto>>(list, _mapper);

            return Ok(response);
        }
        [HttpGet("GetPersonaNaturalViewById")]
        public async Task<IActionResult> GetPersonaNaturalViewById(int idPersona)
        {
            var entity = await _personaService.GetPersonaNaturalViewById(idPersona);
            var response = new ApiResponse<PersonaNaturalViewDto>(entity, _mapper);

            return Ok(response);
        }
        [HttpPost("PostPersonaNatural")]
        public async Task<IActionResult> PostPersonaNatural(PersonaNaturalDto personaNaturalDto)
        {
            var entity = _mapper.Map<PersonaNatural>(personaNaturalDto);
            await _personaService.AddPersonaNatural(entity);
            var response = new ApiResponse<bool>(true);

            return Ok(response);
        }
        [HttpGet("GetPersonasDocumentosViewByIdPersona")]
        public async Task<IActionResult> GetPersonasDocumentosViewByIdPersona(int idPersona)
        {
            var list = await _personaService.GetPersonasDocumentosViewByIdPersona(idPersona);
            var response = new ApiResponse<IEnumerable<PersonaDocumentoViewDto>>(list, _mapper);

            return Ok(response);
        }
        [HttpGet("GetPersonasContactosViewByIdPersona")]
        public async Task<IActionResult> GetPersonasContactosViewByIdPersona(int idPersona)
        {
            var list = await _personaService.GetPersonasContactosViewByIdPersona(idPersona);
            var response = new ApiResponse<IEnumerable<PersonaContactoViewDto>>(list, _mapper);

            return Ok(response);
        }
        [HttpGet("GetPersonasDireccionesViewByIdPersona")]
        public async Task<IActionResult> GetPersonasDireccionesViewByIdPersona(int idPersona)
        {
            var list = await _personaService.GetPersonasDireccionesViewByIdPersona(idPersona);
            var response = new ApiResponse<IEnumerable<PersonaDireccionViewDto>>(list, _mapper);

            return Ok(response);
        }
        [HttpGet("GetPersonasVinculacionesViewByIdPersona")]
        public async Task<IActionResult> GetPersonasVinculacionesViewByIdPersona(int idPersona)
        {
            var list = await _personaService.GetPersonasVinculacionesViewByIdPersona(idPersona);
            var response = new ApiResponse<IEnumerable<PersonaVinculacionViewDto>>(list, _mapper);

            return Ok(response);
        }
        [HttpGet("GetPersonasDocumentosViewByNumeroDocumentoYNombres")]
        public IActionResult GetPersonasDocumentosViewByNumeroDocumentoYNombres(string numeroDocumento, string nombres)
        {
            var list = _personaService.GetPersonasDocumentosViewByNumeroDocumentoYNombres(numeroDocumento, nombres);
            var response = new ApiResponse<IEnumerable<PersonaDocumentoViewDto>>(list, _mapper);

            return Ok(response);
        }
    }
}
