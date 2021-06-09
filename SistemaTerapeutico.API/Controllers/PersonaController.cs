using Microsoft.AspNetCore.Mvc;
using SistemaTerapeutico.Aplicacion.Servicios.Persona;

namespace SistemaTerapeutico.API.Controllers
{
    [Route("[controller]")]
    public class PersonaController : Controller
    {

        private readonly IObtenerdorPersonasServicio _obtenedorPeronasServicios;

        public PersonaController(
            IObtenerdorPersonasServicio obtenedorPeronasServicios
        )
        {
            _obtenedorPeronasServicios = obtenedorPeronasServicios;
        }

        [HttpGet]
        public IActionResult GetPersonas() => Ok(_obtenedorPeronasServicios.Obtener());

    }
}