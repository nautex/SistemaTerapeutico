using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SistemaTerapeutico.Aplicacion.Servicios.Persona;

namespace SistemaTerapeutico.API.Controllers
{
    [Route("[controller]")]
    public class PersonaController : Controller
    {

        private readonly IObtenerdorPersonasServicio _obtenedorPeronasServicios;
        private readonly IMapper _mapper;

        public PersonaController(
            IObtenerdorPersonasServicio obtenedorPeronasServicios
        )
        {
            _obtenedorPeronasServicios = obtenedorPeronasServicios;

            int[] enteros = new int[] { 1, 2, 3, 4 };
        }

        [HttpGet]
        public IActionResult GetPersonas() => Ok(_obtenedorPeronasServicios.Obtener());

    }
}