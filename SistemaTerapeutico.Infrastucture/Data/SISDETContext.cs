using Microsoft.EntityFrameworkCore;
using SistemaTerapeutico.Core.Entities;
using SistemaTerapeutico.Infrastucture.Data.Configurations;

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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CatalogoConfiguration());
            modelBuilder.ApplyConfiguration(new PersonaConfiguration());
            modelBuilder.ApplyConfiguration(new PersonaContactoConfiguration());
            modelBuilder.ApplyConfiguration(new PersonaDireccionConfiguration());
            modelBuilder.ApplyConfiguration(new PersonaDocumentoConfiguration());
            modelBuilder.ApplyConfiguration(new PersonaNaturalConfiguration());
            modelBuilder.ApplyConfiguration(new PersonaVinculacionConfiguration());
            modelBuilder.ApplyConfiguration(new UbigeoConfiguration());
            modelBuilder.ApplyConfiguration(new DireccionConfiguration());
            modelBuilder.ApplyConfiguration(new ParticipanteConfiguration());
        }

    }
}
