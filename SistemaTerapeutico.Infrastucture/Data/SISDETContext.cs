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
        public virtual DbSet<Persona> Persona { get; set; }
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
        public virtual DbSet<PersonaView> PersonaView { get; set; }
        public virtual DbSet<ParticipanteView> ParticipanteView { get; set; }
        public virtual DbSet<AtencionTerapia> AtencionTerapia { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
