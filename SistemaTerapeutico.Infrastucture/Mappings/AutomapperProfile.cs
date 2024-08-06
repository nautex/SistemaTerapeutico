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
                .ForMember(dest => dest.Numero, conf => conf.MapFrom(src => src.IdTwo))
                .ReverseMap();

            CreateMap<Atencion, AtencionDto>()
                .ForMember(dest => dest.IdAtencion, conf => conf.MapFrom(src => src.Id))
                .ReverseMap();

            CreateMap<Participante, ParticipanteDto>().ReverseMap();

            CreateMap<Periodo, PeriodoDto>()
                .ForMember(dest => dest.IdPeriodo, conf => conf.MapFrom(src => src.Id))
                .ReverseMap();

            CreateMap<PersonaDocumento, PersonaDocumentoDto>()
                .ForMember(dest => dest.IdPersona, conf => conf.MapFrom(src => src.Id))
                .ForMember(dest => dest.Numero, conf => conf.MapFrom(src => src.IdTwo))
                .ReverseMap();

            CreateMap<TerapiaPeriodo, TerapiaPeriodoDto>().ReverseMap();

            CreateMap<Direccion, DireccionDto>()
                .ForMember(dest => dest.IdDireccion, conf => conf.MapFrom(src => src.Id))
                .ReverseMap();

            CreateMap<PersonaResumenView, PersonaResumenViewDto>()
                .ReverseMap();

            CreateMap<ParticipanteResumenView, ParticipanteResumenViewDto>()
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
                .ReverseMap();

            CreateMap<PersonaVinculacionView, PersonaVinculacionViewDto>()
                .ReverseMap();

            CreateMap<Persona, PersonaNaturalWDDto>()
                .ReverseMap();

            CreateMap<PersonaNatural, PersonaNaturalWDDto>()
                .ReverseMap();

            CreateMap<PersonaDireccion, PersonaDireccionViewDto>()
                .ForMember(dest => dest.IdPersona, conf => conf.MapFrom(src => src.Id))
                .ForMember(dest => dest.Numero, conf => conf.MapFrom(src => src.IdTwo))
                .ReverseMap();

            CreateMap<PersonaDocumento, PersonaDocumentoViewDto>()
                .ForMember(dest => dest.IdPersona, conf => conf.MapFrom(src => src.Id))
                .ForMember(dest => dest.Numero, conf => conf.MapFrom(src => src.IdTwo))
                .ReverseMap();

            CreateMap<PersonaContacto, PersonaContactoViewDto>()
                .ForMember(dest => dest.IdPersona, conf => conf.MapFrom(src => src.Id))
                .ForMember(dest => dest.Numero, conf => conf.MapFrom(src => src.IdTwo))
                .ReverseMap();

            CreateMap<PersonaVinculacion, PersonaVinculacionViewDto>()
                .ForMember(dest => dest.IdPersona, conf => conf.MapFrom(src => src.Id))
                .ForMember(dest => dest.Numero, conf => conf.MapFrom(src => src.IdTwo))
                .ReverseMap();

            CreateMap<PersonaResumenBasicoView, PersonaResumenBasicoViewDto>().ReverseMap();
            CreateMap<ParticipanteResumenView, ParticipanteResumenViewDto>().ReverseMap();
            CreateMap<ParticipanteAlergiaView, ParticipanteAlergiaViewDto>().ReverseMap();
            CreateMap<ParticipantePersonaAutorizadaView, ParticipantePersonaAutorizadaViewDto>().ReverseMap();
            CreateMap<ParticipanteView, ParticipanteViewDto>().ReverseMap();

            CreateMap<TerapiaView, TerapiaViewDto>().ReverseMap();
            CreateMap<TerapiaResumenView, TerapiaResumenViewDto>().ReverseMap();
            CreateMap<TerapiaTerapeutaView, TerapiaTerapeutaViewDto>().ReverseMap();
            CreateMap<TerapiaHorarioView, TerapiaHorarioViewDto>().ReverseMap();
            CreateMap<TerapiaParticipanteView, TerapiaParticipanteViewDto>().ReverseMap();
            CreateMap<TerapiaParticipante, TerapiaParticipanteViewDto>().ReverseMap();
            CreateMap<TerapiaParticipanteResumenView, TerapiaParticipanteResumenViewDto>().ReverseMap();
            CreateMap<TerapiaPeriodoResumenView, TerapiaPeriodoResumenViewDto>().ReverseMap();
            CreateMap<PeriodoView, PeriodoViewDto>().ReverseMap();

            CreateMap<LocalView, LocalViewDto>().ReverseMap();

            CreateMap<SalonView, SalonViewDto>().ReverseMap();

            CreateMap<TarifaView, TarifaViewDto>().ReverseMap();

            CreateMap<Servicio, ServicioDto>().ReverseMap();

            CreateMap<Sesion, SesionDto>().ReverseMap();
            CreateMap<SesionView, SesionViewDto>().ReverseMap();
            CreateMap<SesionResumenView, SesionResumenViewDto>().ReverseMap();
            CreateMap<SesionTerapeutaView, SesionTerapeutaViewDto>().ReverseMap();
            CreateMap<SesionCriterioView, SesionCriterioViewDto>().ReverseMap();

            CreateMap<Modelo, ModeloDto>().ReverseMap();
            CreateMap<Area, AreaDto>().ReverseMap();
            CreateMap<AreaObjetivo, AreaObjetivoDto>().ReverseMap();
            CreateMap<AreaObjetivoCriterio, AreaObjetivoCriterioDto>().ReverseMap();
            CreateMap<AreaObjetivoCriterioView, AreaObjetivoCriterioViewDto>().ReverseMap();

            CreateMap<TerapiaPlan, TerapiaPlanDto>().ReverseMap();
            CreateMap<TerapiaPlanView, TerapiaPlanViewDto>().ReverseMap();
            CreateMap<TerapiaPlanArea, TerapiaPlanAreaDto>().ReverseMap();
            CreateMap<TerapiaPlanAreaView, TerapiaPlanAreaViewDto>().ReverseMap();
            CreateMap<TerapiaPlanResumenView, TerapiaPlanResumenViewDto>().ReverseMap();

            CreateMap<PuntuacionGrupo, PuntuacionGrupoDto>().ReverseMap();
        }
    }
}
