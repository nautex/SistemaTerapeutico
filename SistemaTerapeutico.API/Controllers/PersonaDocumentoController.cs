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
        public async Task<IActionResult> GetPersonaDocumentoByTipoYNumero(DocumentoTipoNumeroDto tipoDocumentoNumeroDto)
        {
            var PersonasDocumentos = await _personaDocumentoService.GetPersonasDocumentosByTipoYNumero(tipoDocumentoNumeroDto.IdTipoDocumento, tipoDocumentoNumeroDto.Numero);
            var Response = new ApiResponse<IEnumerable<PersonaDocumento>>(PersonasDocumentos);
            return Ok(Response);
        }
        [HttpPost("PostPersonaDocumento")]
        public async Task<IActionResult> PostPersonaDocumento (PersonaDocumentoDto personaDocumentoDto)
        {
            PersonaDocumento lPersonaDocumento = new PersonaDocumento(personaDocumentoDto.UsuarioRegistro)
            {
                Id = personaDocumentoDto.Id,
                IdTipoDocumento = personaDocumentoDto.IdTipoDocumento,
                Numero = personaDocumentoDto.Numero
            };
            await _personaDocumentoService.AddPersonaDocumento(lPersonaDocumento);
            var Response = new ApiResponse<bool>(true);
            return Ok(Response);
        }
    }
}
