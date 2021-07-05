﻿using System.Collections.Generic;
using System.Threading.Tasks;
using SistemaTerapeutico.Core.DTOs;
using SistemaTerapeutico.Core.Entities;

namespace SistemaTerapeutico.Core.Services
{
    public interface IPersonaService
    {
        Task<IEnumerable<Persona>> GetPersonas();
        Task<Persona> GetPersonaById(int idPersona);
        Task AddPersona(Persona persona);
        void UpdatePersona(Persona persona);
        Task DeletePersona(int idPersona);
        Task<int> AddPersonaParticipanteFichaRegistro(PersonaParticipanteFichaRegistroDto personaResumenBasicoDto);
    }
}