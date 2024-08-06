using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using SistemaTerapeutico.Core.Entities;
using SistemaTerapeutico.Core.Views;

namespace SistemaTerapeutico.Infrastucture.Data
{
    public partial class SISDETContext : DbContext
    {
        public SISDETContext()
        {
        }

        public SISDETContext(DbContextOptions<SISDETContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Catalogo> Catalogo { get; set; }
        public virtual DbSet<Persona> Persona { get; set; } //41424344454647484950515253545556575859606162636465666768697071727374757677787980
        public virtual DbSet<PersonaContacto> PersonaContacto { get; set; }
        public virtual DbSet<PersonaDireccion> PersonaDireccion { get; set; }
        public virtual DbSet<PersonaDocumento> PersonaDocumento { get; set; }
        public virtual DbSet<PersonaNatural> PersonaNatural { get; set; }
        public virtual DbSet<PersonaVinculacion> PersonaVinculacion { get; set; }
        public virtual DbSet<Ubigeo> Ubigeo { get; set; }
        public virtual DbSet<Direccion> Direccion { get; set; }
        public virtual DbSet<Participante> Participante { get; set; }
        public virtual DbSet<Atencion> Atencion { get; set; }
        public virtual DbSet<Terapia> Terapia { get; set; }
        public virtual DbSet<TerapiaTerapeuta> TerapiaTerapeuta { get; set; }
        public virtual DbSet<TerapiaPeriodo> TerapiaPeriodo { get; set; }
        public virtual DbSet<TerapiaHorario> TerapiaHorario { get; set; }
        public virtual DbSet<TerapiaParticipante> TerapiaParticipante { get; set; }
        public virtual DbSet<TerapiaView> TerapiaView { get; set; }
        public virtual DbSet<TerapiaHorarioView> TerapiaHorarioView { get; set; }
        public virtual DbSet<TerapiaTerapeutaView> TerapiaTerapeutaView { get; set; }
        public virtual DbSet<TerapiaParticipanteView> TerapiaParticipanteView { get; set; }
        public virtual DbSet<TerapiaResumenView> TerapiaResumenView { get; set; }
        public virtual DbSet<Periodo> Periodo { get; set; }
        public virtual DbSet<Usuario> Usuario { get; set; }
        public virtual DbSet<PersonaResumenView> PersonaView { get; set; }
        public virtual DbSet<ParticipanteResumenView> ParticipanteResumenView { get; set; }
        public virtual DbSet<AtencionTerapia> AtencionTerapia { get; set; }
        public virtual DbSet<PersonaNaturalView> PersonaNaturalView { get; set; }
        public virtual DbSet<UbigeoView> UbigeoView { get; set; }
        public virtual DbSet<PersonaContactoView> PersonaContactoView { get; set; }
        //8182884858687888990919293949596979899100
        public virtual DbSet<PersonaDocumentoView> PersonaDocumentoView { get; set; }
        public virtual DbSet<PersonaDireccionView> PersonaDireccionView { get; set; }
        public virtual DbSet<DireccionView> DireccionView { get; set; }
        public virtual DbSet<PersonaVinculacionView> PersonaVinculacionView { get; set; }
        public virtual DbSet<PersonaResumenBasicoView> PersonaResumenBasicoView { get; set; }
        public virtual DbSet<ParticipanteAlergia> ParticipanteAlergia { get; set; }
        public virtual DbSet<ParticipanteAlergiaView> ParticipanteAlergiaView { get; set; }
        public virtual DbSet<ParticipantePersonaAutorizada> ParticipantePersonaAutorizada { get; set; }
        public virtual DbSet<ParticipantePersonaAutorizadaView> ParticipantePersonaAutorizadaView { get; set; }
        public virtual DbSet<ParticipanteView> ParticipanteView { get; set; }
        public virtual DbSet<LocalView> LocalView { get; set; }
        public virtual DbSet<SalonView> SalonView { get; set; }
        public virtual DbSet<TarifaView> TarifaView { get; set; }
        public virtual DbSet<Servicio> Servicio { get; set; }
        public virtual DbSet<TerapiaParticipanteResumenView> TerapiaParticipanteResumenView { get; set; }
        public virtual DbSet<TerapiaPeriodoResumenView> TerapiaPeriodoResumenView { get; set; }
        public virtual DbSet<PeriodoView> PeriodoView { get; set; }
        public virtual DbSet<Sesion> Sesion { get; set; }
        public virtual DbSet<SesionCriterio> SesionCriterio { get; set; }
        public virtual DbSet<SesionCriterioView> SesionCriterioView { get; set; }
        public virtual DbSet<SesionCriterioActividad> SesionCriterioActividad { get; set; }
        public virtual DbSet<SesionView> SesionView { get; set; }
        public virtual DbSet<SesionTerapeuta> SesionTerapeuta { get; set; }
        public virtual DbSet<SesionTerapeutaView> SesionTerapeutaView { get; set; }
        public virtual DbSet<Tarifa> Tarifa { get; set; }
        public virtual DbSet<AreaObjetivoCriterioView> AreaObjetivoCriterioView { get; set; }
        public virtual DbSet<TerapiaPlan> TerapiaPlan { get; set; }
        public virtual DbSet<TerapiaPlanView> TerapiaPlanView { get; set; }
        public virtual DbSet<TerapiaPlanArea> TerapiaPlanArea { get; set; }
        public virtual DbSet<TerapiaPlanAreaView> TerapiaPlanAreaView { get; set; }
        public virtual DbSet<TerapiaPlanResumenView> TerapiaPlanResumenView { get; set; }
        public virtual DbSet<Modelo> Modelo { get; set; }
        public virtual DbSet<Area> Area { get; set; }
        public virtual DbSet<AreaObjetivo> AreaObjetivo { get; set; }
        public virtual DbSet<AreaObjetivoCriterio> AreaObjetivoCriterio { get; set; }
        public virtual DbSet<PuntuacionGrupo> PuntuacionGrupo { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
