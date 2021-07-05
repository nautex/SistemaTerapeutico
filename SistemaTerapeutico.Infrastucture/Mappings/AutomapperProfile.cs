using AutoMapper;
using SistemaTerapeutico.Core.DTOs;
using SistemaTerapeutico.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SistemaTerapeutico.Infrastucture.Mappings
{
    public class AutomapperProfile : Profile
    {
        public AutomapperProfile()
        {
            CreateMap<Persona, PersonaDto>();
            CreateMap<PersonaDto, Persona>();
        }
    }
}
