using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SistemaTerapeutico.API.Response;
using SistemaTerapeutico.Core.DTOs;
using SistemaTerapeutico.Core.Entities;
using SistemaTerapeutico.Core.Interfaces;
using SistemaTerapeutico.Infrastucture.Services;

namespace SistemaTerapeutico.API.Controllers
{
    //[Authorize]
    [Route("[controller]")]
    public class PersonaController : Controller
    {
        private readonly PersonaService _personaService;
        private readonly IMapper _mapper;

        public PersonaController(PersonaService personaService, IMapper mapper)
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
        [HttpPost("PostPersonaNaturalUpdateWithDetails")]
        public async Task<IActionResult> PostPersonaNaturalUpdateWithDetails([FromBody] PersonaNaturalWDDto personaDto)
        {
            Persona persona = _mapper.Map<Persona>(personaDto);
            persona.PersonaNatural = _mapper.Map<PersonaNatural>(personaDto);
            int idPersona = await _personaService.AddPersonaNaturalWithDetails(persona);
            var Response = new ApiResponse<int>(idPersona);

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
        [HttpGet("GetPersonaJuridicaViewById")]
        public async Task<IActionResult> GetPersonaJuridicaViewById(int idPersona)
        {
            var entity = await _personaService.GetPersonaJuridicaViewById(idPersona);
            var response = new ApiResponse<PersonaJuridicaViewDto>(entity, _mapper);

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
        [HttpGet("GetPersonasAntecedentesViewByIdPersona")]
        public async Task<IActionResult> GetPersonasAntecedentesViewByIdPersona(int idPersona)
        {
            var list = await _personaService.GetPersonasAntecedenteViewByIdPersona(idPersona);
            var response = new ApiResponse<IEnumerable<PersonaAntecedenteViewDto>>(list, _mapper);

            return Ok(response);
        }
        [HttpGet("GetsPersonaRepresentanteViewById")]
        public async Task<IActionResult> GetsPersonaRepresentanteViewById(int idPersona)
        {
            var list = await _personaService.GetsPersonaRepresentanteViewById(idPersona);
            var response = new ApiResponse<IEnumerable<PersonaRepresentanteViewDto>>(list, _mapper);

            return Ok(response);
        }
        [HttpGet("GetPersonasResumenBasicoViewByNumeroDocumentoYNombres")]
        public IActionResult GetPersonasResumenBasicoViewByNumeroDocumentoYNombres(string numeroDocumento, string nombres, string empresa)
        {
            var list = _personaService.GetPersonasResumenBasicoViewByNumeroDocumentoYNombres(numeroDocumento, nombres, empresa);
            var response = new ApiResponse<IEnumerable<PersonaResumenBasicoViewDto>>(list, _mapper);

            return Ok(response);
        }

        [HttpGet("GetPersonasResumenViewByNumeroDocumentoYNombres")]
        public IActionResult GetPersonasResumenViewByNumeroDocumentoYNombres(string numeroDocumento, string nombres, string empresa)
        {
            var list = _personaService.GetPersonasResumenViewByNumeroDocumentoYNombres(numeroDocumento, nombres, empresa);
            var response = new ApiResponse<IEnumerable<PersonaResumenViewDto>>(list, _mapper);

            return Ok(response);
        }
        [HttpDelete("DeletePersonaDireccion")]
        public async Task<IActionResult> DeletePersonaDireccion(int idPersona, int numero)
        {
            await _personaService.DeletePersonaDireccion(idPersona, numero);
            var response = new ApiResponse<bool>(true);

            return Ok(response);
        }
        [HttpDelete("DeletePersonaDocumento")]
        public async Task<IActionResult> DeletePersonaDocumento(int idPersona, int numero)
        {
            await _personaService.DeletePersonaDocumento(idPersona, numero);
            var response = new ApiResponse<bool>(true);

            return Ok(response);
        }
        [HttpDelete("DeletePersonaContacto")]
        public async Task<IActionResult> DeletePersonaContacto(int idPersona, int numero)
        {
            await _personaService.DeletePersonaContacto(idPersona, numero);
            var response = new ApiResponse<bool>(true);

            return Ok(response);
        }
        [HttpDelete("DeletePersonaVinculacion")]
        public async Task<IActionResult> DeletePersonaVinculacion(int idPersona, int numero)
        {
            await _personaService.DeletePersonaVinculacion(idPersona, numero);
            var response = new ApiResponse<bool>(true);

            return Ok(response);
        }
        [HttpDelete("DeletePersonaAntecedente")]
        public async Task<IActionResult> DeletePersonaAntecedente(int idPersona, int numero)
        {
            await _personaService.DeletePersonaAntecedente(idPersona, numero);
            var response = new ApiResponse<bool>(true);

            return Ok(response);
        }
        [HttpGet("GetsListNaturalPersonByTypeAndName")]
        public IActionResult GetsListPersonByTypeAndName(int idType, string name)
        {
            var list = _personaService.GetsListNaturalPersonByTypeAndName(idType, name);
            var response = new ApiResponse<IEnumerable<ListaDto>>(list, _mapper);

            return Ok(response);
        }
        [HttpGet("GetsListLegalPersonByTypeAndName")]
        public IActionResult GetsListLegalPersonByTypeAndName(int idType, string name)
        {
            var list = _personaService.GetsListLegalPersonByTypeAndName(idType, name);
            var response = new ApiResponse<IEnumerable<ListaDto>>(list, _mapper);

            return Ok(response);
        }
        [HttpPost("AddPersonaVinculacion")]
        public async Task<IActionResult> AddPersonaVinculacion([FromBody] PersonaVinculacionDto personaVinculacionDto)
        {
            PersonaVinculacion personaVinculacion = _mapper.Map<PersonaVinculacion>(personaVinculacionDto);
            await _personaService.AddPersonaVinculacion(personaVinculacion);
            var Response = new ApiResponse<int>(1);

            return Ok(Response);
        }
        [HttpGet("GetPersonaResumenBasicoViewByTipoDocumentoAndNumeroDocumento")]
        public IActionResult GetPersonaResumenBasicoViewByTipoDocumentoAndNumeroDocumento(int idTipoDocumento, string numeroDocumento)
        {
            var list = _personaService.GetPersonaResumenBasicoViewByTipoDocumentoAndNumeroDocumento(idTipoDocumento, numeroDocumento);
            var response = new ApiResponse<PersonaResumenBasicoViewDto>(list, _mapper);

            return Ok(response);
        }

        [HttpGet("GetsPersonaDocumentoByTipoYNumero")]
        public async Task<IActionResult> GetsPersonaDocumentoByTipoYNumero(int idTipoDocumento, string numeroDocumento)
        {
            var list = await _personaService.GetsPersonaDocumentoByTipoYNumero(idTipoDocumento, numeroDocumento);
            var response = new ApiResponse<IEnumerable<PersonaDocumentoDto>>(list, _mapper);

            return Ok(response);
        }
    }
}
