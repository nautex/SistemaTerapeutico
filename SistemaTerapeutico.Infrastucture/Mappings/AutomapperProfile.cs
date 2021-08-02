using AutoMapper;
using SistemaTerapeutico.Core.DTOs;
using SistemaTerapeutico.Core.Entities;

namespace SistemaTerapeutico.Infrastucture.Mappings
{
    public class AutomapperProfile : Profile
    {
        public AutomapperProfile()
        {
            CreateMap<Persona, PersonaDto>()
                .ForMember(dest => dest.IdPersona, conf => conf.MapFrom(src => src.Id))
                .ForMember(dest => dest.Usuario, conf => conf.MapFrom(src => src.UsuarioRegistro))
                .ReverseMap();

            CreateMap<PersonaVinculacion, PersonaVinculacionDto>()
                .ForMember(dest => dest.IdPersona, conf => conf.MapFrom(src => src.Id))
                .ForMember(dest => dest.Usuario, conf => conf.MapFrom(src => src.UsuarioRegistro))
                .ReverseMap();

            CreateMap<Atencion, AtencionDto>()
                .ForMember(dest => dest.IdAtencion, conf => conf.MapFrom(src => src.Id))
                .ForMember(dest => dest.Usuario, conf => conf.MapFrom(src => src.UsuarioRegistro))
                .ReverseMap();

            CreateMap<Participante, ParticipanteDto>()
                .ForMember(dest => dest.IdParticipante, conf => conf.MapFrom(src => src.Id))
                .ForMember(dest => dest.Usuario, conf => conf.MapFrom(src => src.UsuarioRegistro))
                .ReverseMap();

            CreateMap<Periodo, PeriodoDto>()
                .ForMember(dest => dest.IdPeriodo, conf => conf.MapFrom(src => src.Id))
                .ForMember(dest => dest.Usuario, conf => conf.MapFrom(src => src.UsuarioRegistro))
                .ReverseMap();

            CreateMap<PersonaDocumento, PersonaDocumentoDto>()
                .ForMember(dest => dest.IdPersona, conf => conf.MapFrom(src => src.Id))
                .ForMember(dest => dest.IdTipoDocumento, conf => conf.MapFrom(src => src.IdTwo))
                .ForMember(dest => dest.Usuario, conf => conf.MapFrom(src => src.UsuarioRegistro))
                .ReverseMap();

            CreateMap<SesionCriterioActividad, SesionCriterioActividadDto>()
                .ForMember(dest => dest.IdSesion, conf => conf.MapFrom(src => src.Id))
                .ForMember(dest => dest.IdObjetivoCriterio, conf => conf.MapFrom(src => src.IdTwo))
                .ForMember(dest => dest.IdActividad, conf => conf.MapFrom(src => src.IdThree))
                .ForMember(dest => dest.Usuario, conf => conf.MapFrom(src => src.UsuarioRegistro))
                .ReverseMap();

            CreateMap<SesionCriterio, SesionCriterioDto>()
                .ForMember(dest => dest.IdSesion, conf => conf.MapFrom(src => src.Id))
                .ForMember(dest => dest.IdObjetivoCriterio, conf => conf.MapFrom(src => src.IdTwo))
                .ForMember(dest => dest.Usuario, conf => conf.MapFrom(src => src.UsuarioRegistro))
                .ReverseMap();

            CreateMap<Sesion, SesionDto>()
                .ForMember(dest => dest.IdSesion, conf => conf.MapFrom(src => src.Id))
                .ForMember(dest => dest.Usuario, conf => conf.MapFrom(src => src.UsuarioRegistro))
                .ReverseMap();

            CreateMap<Terapia, TerapiaDto>()
                .ForMember(dest => dest.IdTerapia, conf => conf.MapFrom(src => src.Id))
                .ForMember(dest => dest.Usuario, conf => conf.MapFrom(src => src.UsuarioRegistro))
                .ReverseMap();

            CreateMap<TerapiaPeriodo, TerapiaPeriodoDto>()
                .ForMember(dest => dest.IdTerapia, conf => conf.MapFrom(src => src.Id))
                .ForMember(dest => dest.IdPeriodo, conf => conf.MapFrom(src => src.IdTwo))
                .ForMember(dest => dest.Usuario, conf => conf.MapFrom(src => src.UsuarioRegistro))
                .ReverseMap();

            CreateMap<TerapiaPlanificacion, TerapiaPlanificacionDto>()
                .ForMember(dest => dest.IdTerapia, conf => conf.MapFrom(src => src.Id))
                .ForMember(dest => dest.IdPeriodo, conf => conf.MapFrom(src => src.IdTwo))
                .ForMember(dest => dest.Usuario, conf => conf.MapFrom(src => src.UsuarioRegistro))
                .ReverseMap();

            CreateMap<TerapiaPlanificacionCriterio, TerapiaPlanificacionCriterioDto>()
                .ForMember(dest => dest.IdTerapia, conf => conf.MapFrom(src => src.Id))
                .ForMember(dest => dest.IdPeriodo, conf => conf.MapFrom(src => src.IdTwo))
                .ForMember(dest => dest.IdObjetivoCriterio, conf => conf.MapFrom(src => src.IdThree))
                .ForMember(dest => dest.Usuario, conf => conf.MapFrom(src => src.UsuarioRegistro))
                .ReverseMap();

            CreateMap<TerapiaTerapeuta, TerapiaTerapeutaDto>()
                .ForMember(dest => dest.IdTerapia, conf => conf.MapFrom(src => src.Id))
                .ForMember(dest => dest.IdTerapeuta, conf => conf.MapFrom(src => src.IdTwo))
                .ForMember(dest => dest.Usuario, conf => conf.MapFrom(src => src.UsuarioRegistro))
                .ReverseMap();
        }
    }
}
