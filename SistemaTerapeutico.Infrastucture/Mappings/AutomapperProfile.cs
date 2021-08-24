using AutoMapper;
using SistemaTerapeutico.Core.DTOs;
using SistemaTerapeutico.Core.Entities;
using SistemaTerapeutico.Core.Views;

namespace SistemaTerapeutico.Infrastucture.Mappings
{
    public class AutomapperProfile : Profile
    {
        public AutomapperProfile()
        {
            CreateMap<Lista, ListaDto>()
                .ReverseMap();

            CreateMap<Persona, PersonaDto>()
                .ForMember(dest => dest.IdPersona, conf => conf.MapFrom(src => src.Id))
                .ReverseMap();

            CreateMap<PersonaNatural, PersonaNaturalDto>()
                .ForMember(dest => dest.IdPersona, conf => conf.MapFrom(src => src.Id))
                .ReverseMap();

            CreateMap<PersonaVinculacion, PersonaVinculacionDto>()
                .ForMember(dest => dest.IdPersona, conf => conf.MapFrom(src => src.Id))
                .ReverseMap();

            CreateMap<Atencion, AtencionDto>()
                .ForMember(dest => dest.IdAtencion, conf => conf.MapFrom(src => src.Id))
                .ReverseMap();

            CreateMap<Participante, ParticipanteDto>()
                .ForMember(dest => dest.IdParticipante, conf => conf.MapFrom(src => src.Id))
                .ReverseMap();

            CreateMap<Periodo, PeriodoDto>()
                .ForMember(dest => dest.IdPeriodo, conf => conf.MapFrom(src => src.Id))
                .ReverseMap();

            CreateMap<PersonaDocumento, PersonaDocumentoDto>()
                .ForMember(dest => dest.IdPersona, conf => conf.MapFrom(src => src.Id))
                .ForMember(dest => dest.IdTipoDocumento, conf => conf.MapFrom(src => src.IdTwo))
                .ReverseMap();

            CreateMap<SesionCriterioActividad, SesionCriterioActividadDto>()
                .ForMember(dest => dest.IdSesion, conf => conf.MapFrom(src => src.Id))
                .ForMember(dest => dest.IdObjetivoCriterio, conf => conf.MapFrom(src => src.IdTwo))
                .ForMember(dest => dest.IdActividad, conf => conf.MapFrom(src => src.IdThree))
                .ReverseMap();

            CreateMap<SesionCriterio, SesionCriterioDto>()
                .ForMember(dest => dest.IdSesion, conf => conf.MapFrom(src => src.Id))
                .ForMember(dest => dest.IdObjetivoCriterio, conf => conf.MapFrom(src => src.IdTwo))
                .ReverseMap();

            CreateMap<Sesion, SesionDto>()
                .ForMember(dest => dest.IdSesion, conf => conf.MapFrom(src => src.Id))
                .ReverseMap();

            CreateMap<Terapia, TerapiaDto>()
                .ForMember(dest => dest.IdTerapia, conf => conf.MapFrom(src => src.Id))
                .ReverseMap();

            CreateMap<TerapiaPeriodo, TerapiaPeriodoDto>()
                .ForMember(dest => dest.IdTerapia, conf => conf.MapFrom(src => src.Id))
                .ForMember(dest => dest.IdPeriodo, conf => conf.MapFrom(src => src.IdTwo))
                .ReverseMap();

            CreateMap<TerapiaPlanificacion, TerapiaPlanificacionDto>()
                .ForMember(dest => dest.IdTerapia, conf => conf.MapFrom(src => src.Id))
                .ForMember(dest => dest.IdPeriodo, conf => conf.MapFrom(src => src.IdTwo))
                .ReverseMap();

            CreateMap<TerapiaPlanificacionCriterio, TerapiaPlanificacionCriterioDto>()
                .ForMember(dest => dest.IdTerapia, conf => conf.MapFrom(src => src.Id))
                .ForMember(dest => dest.IdPeriodo, conf => conf.MapFrom(src => src.IdTwo))
                .ForMember(dest => dest.IdObjetivoCriterio, conf => conf.MapFrom(src => src.IdThree))
                .ReverseMap();

            CreateMap<TerapiaTerapeuta, TerapiaTerapeutaDto>()
                .ForMember(dest => dest.IdTerapia, conf => conf.MapFrom(src => src.Id))
                .ForMember(dest => dest.IdTerapeuta, conf => conf.MapFrom(src => src.IdTwo))
                .ReverseMap();

            CreateMap<Direccion, DireccionDto>()
                .ForMember(dest => dest.IdDireccion, conf => conf.MapFrom(src => src.Id))
                .ReverseMap();

            CreateMap<PersonaResumenView, PersonaResumenViewDto>()
                //.ForMember(dest => dest.Id, conf => conf.MapFrom(src => src.Id))
                .ReverseMap();

            CreateMap<ParticipanteResumenView, ParticipanteViewDto>()
                .ForMember(dest => dest.IdParticipante, conf => conf.MapFrom(src => src.Id))
                .ReverseMap();

            CreateMap<AtencionTerapia, AtencionTerapiaDto>()
                .ForMember(dest => dest.IdAtencion, conf => conf.MapFrom(src => src.Id))
                .ForMember(dest => dest.IdTerapia, conf => conf.MapFrom(src => src.IdTwo))
                .ReverseMap();

            CreateMap<Lista, ListaDto>()
                .ReverseMap();

            CreateMap<PersonaNaturalView, PersonaNaturalViewDto>()
                .ReverseMap();

            CreateMap<UbigeoView, UbigeoViewDto>()
                .ReverseMap();

            CreateMap<Catalogo, CatalogoDto>()
                .ForMember(dest => dest.IdCatalogo, conf => conf.MapFrom(src => src.Id))
                .ReverseMap();

            CreateMap<PersonaDocumentoView, PersonaDocumentoViewDto>()
                .ReverseMap();

            CreateMap<PersonaContactoView, PersonaContactoViewDto>()
                .ReverseMap();

            CreateMap<PersonaDireccionView, PersonaDireccionViewDto>()
                .ReverseMap();

            CreateMap<DireccionView, DireccionViewDto>()
                .ForMember(dest => dest.IdDireccion, conf => conf.MapFrom(src => src.Id))
                .ReverseMap();
        }
    }
}
