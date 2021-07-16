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
        [HttpGet("getPersonaDocumentoByTipoYNumero")]
        public IActionResult getPersonaDocumentoByTipoYNumero(DocumentoTipoNumeroDto tipoDocumentoNumeroDto)
        {
            var PersonasDocumentos = _personaDocumentoService.GetPersonasDocumentosByTipoYNumero(tipoDocumentoNumeroDto.IdTipoDocumento, tipoDocumentoNumeroDto.Numero);
            var Response = new ApiResponse<IEnumerable<PersonaDocumento>>(PersonasDocumentos);
            return Ok(Response);
        }
    }
}
