using System.Reflection;
using Microsoft.EntityFrameworkCore;
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
        public virtual DbSet<Periodo> Periodo { get; set; }
        public virtual DbSet<Sesion> Sesion { get; set; }
        public virtual DbSet<SesionCriterio> SesionCriterio { get; set; }
        public virtual DbSet<SesionCriterioActividad> SesionCriterioActividad { get; set; }
        public virtual DbSet<TerapiaPeriodo> TerapiaPeriodo { get; set; }
        public virtual DbSet<TerapiaPlanificacion> TerapiaPlanificacion { get; set; }
        public virtual DbSet<TerapiaPlanificacionCriterio> TerapiaPlanificacionCriterio { get; set; }
        public virtual DbSet<Usuario> Usuario { get; set; }
        public virtual DbSet<PersonaResumenView> PersonaView { get; set; }
        public virtual DbSet<ParticipanteResumenView> ParticipanteView { get; set; }
        public virtual DbSet<AtencionTerapia> AtencionTerapia { get; set; }
        public virtual DbSet<PersonaNaturalView> PersonaNaturalView { get; set; }
        public virtual DbSet<UbigeoView> UbigeoView { get; set; }
        public virtual DbSet<PersonaContactoView> PersonaContactoView { get; set; }
        //8182884858687888990919293949596979899100
        public virtual DbSet<PersonaDocumentoView> PersonaDocumentoView { get; set; }
        public virtual DbSet<PersonaDireccionView> PersonaDireccionView { get; set; }
        public virtual DbSet<DireccionView> DireccionView { get; set; }
        public virtual DbSet<PersonaVinculacionView> PersonaVinculacionView { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
