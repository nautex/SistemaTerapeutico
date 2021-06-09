using Microsoft.AspNetCore.Mvc;
using SistemaTerapeutico.Core.Entities;
using SistemaTerapeutico.Core.Interfaces;
using System.Threading.Tasks;

namespace SistemaTerapeutico.API.Controllers
{
    [Route("[controller]")]
    public class PersonaController : Controller
    {
        private readonly IPersonaRepository _personaRepository;

        public PersonaController(IPersonaRepository pPersonaRepository)
        {
            _personaRepository = pPersonaRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetPersonas()
        {
            var lPersonas = await _personaRepository.GetPersonas();
            return Ok(lPersonas);
        }

        [HttpGet("{pIdPersona}")]
        public async Task<IActionResult> GetPersonaById(int pIdPersona)
        {
            var lPersona = await _personaRepository.GetPersonaById(pIdPersona);
            return Ok(lPersona);
        }

        [HttpPost]
        public async Task<IActionResult> PostPersona(Persona pPersona)
        {
            await _personaRepository.InsertPersona(pPersona);
            return Ok(pPersona);
        }
    }
}
