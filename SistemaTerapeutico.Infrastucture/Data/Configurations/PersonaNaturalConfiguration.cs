using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemaTerapeutico.Core.Entities;

namespace SistemaTerapeutico.Infrastucture.Data.Configurations
{
    public class PersonaNaturalConfiguration : IEntityTypeConfiguration<PersonaNatural>
    {
        public void Configure(EntityTypeBuilder<PersonaNatural> builder)
        {
            builder.HasKey(e => e.Id)
                    .HasName("PRIMARY");

            builder.ToTable("personanatural");

            builder.HasIndex(e => e.IdUbigeoNacimiento)
                .HasName("FK_PersonaNatural_Ubigeo");

            builder.Property(e => e.Id)
                .HasColumnName("IdPersona")
                .HasColumnType("int(11)");

            builder.Property(e => e.IdEstado)
                .HasColumnType("int(11)")
                .HasDefaultValueSql("'NULL'");

            builder.Property(e => e.IdEstadoCivil)
                .HasColumnType("int(11)")
                .HasDefaultValueSql("'NULL'");

            builder.Property(e => e.IdNacionalidad)
                .HasColumnType("int(11)")
                .HasDefaultValueSql("'NULL'");

            builder.Property(e => e.IdSexo)
                .HasColumnType("int(11)")
                .HasDefaultValueSql("'NULL'");

            builder.Property(e => e.IdUbigeoNacimiento)
                .HasColumnType("int(11)")
                .HasDefaultValueSql("'NULL'");

            builder.Property(e => e.PrimerApellido)
                .HasMaxLength(70)
                .HasDefaultValueSql("'NULL'");

            builder.Property(e => e.PrimerNombre)
                .HasMaxLength(70)
                .HasDefaultValueSql("'NULL'");

            builder.Property(e => e.SegundoApelldio)
                .HasMaxLength(70)
                .HasDefaultValueSql("'NULL'");

            builder.Property(e => e.SegundoNombre)
                .HasMaxLength(70)
                .HasDefaultValueSql("'NULL'");

            builder.Property(e => e.UsuarioModificacion)
                .HasMaxLength(20)
                .HasDefaultValueSql("'NULL'");

            builder.Property(e => e.UsuarioRegistro)
                .HasMaxLength(20)
                .HasDefaultValueSql("'NULL'");

            //builder.HasOne(d => d.IdPersonaNavigation)
            //    .WithOne(p => p.PersonaNatural)
            //    .HasForeignKey<PersonaNatural>(d => d.Id)
            //    .OnDelete(DeleteBehavior.ClientSetNull)
            //    .HasConstraintName("FK_PersonaNatural_Persona1");

            //builder.HasOne(d => d.IdUbigeoNacimientoNavigation)
            //    .WithMany(p => p.PersonaNatural)
            //    .HasForeignKey(d => d.IdUbigeoNacimiento)
            //    .HasConstraintName("FK_PersonaNatural_Ubigeo");
        }
    }
}
