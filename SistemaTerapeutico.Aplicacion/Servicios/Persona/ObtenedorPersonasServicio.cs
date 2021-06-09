using System.Collections.Generic;
using System.Linq;
using SistemaTerapeutico.Core.DTOs;
using SistemaTerapeutico.Core.Interfaces;

namespace SistemaTerapeutico.Aplicacion.Servicios.Persona
{
    public class ObtenedorPersonasServicio : IObtenerdorPersonasServicio
    {
        private readonly IRepository _repositorio;

        public ObtenedorPersonasServicio(IRepository repositorio)
        {
            _repositorio = repositorio;
        }
        public IList<PersonaDto> Obtener() =>
             _repositorio.Listar<Core.Entities.Persona>().Select(g => new PersonaDto
             {
                 Nombres = g.Nombres,
                 RazonSocial = g.RazonSocial
             }).ToList();
    }

    public interface IObtenerdorPersonasServicio
    {
        IList<PersonaDto> Obtener();
    }
}