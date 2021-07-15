using AutoMapper;
using SistemaTerapeutico.Core.DTOs;
using SistemaTerapeutico.Core.Entities;

namespace SistemaTerapeutico.Infrastucture.Mappings
{
    public class AutomapperProfile : Profile
    {
        public AutomapperProfile()
        {
            CreateMap<Persona, PersonaDto>();
            CreateMap<PersonaDto, Persona>();
            CreateMap<PersonaVinculacion, PersonaVinculacionDto>();
            CreateMap<PersonaVinculacionDto, PersonaVinculacion>();
        }
    }
}
