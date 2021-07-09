using System;
using SistemaTerapeutico.Core.Enumerators;

namespace SistemaTerapeutico.Core.Entities
{
    public partial class PersonaNatural : BaseEntity
    {
        public PersonaNatural(string usuarioRegistro) : base(usuarioRegistro)
        {
            PrimerNombre = "";
            SegundoNombre = "";
            PrimerApellido = "";
            SegundoApelldio = "";
            IdUbigeoNacimiento = eUbigeo.Tacna;
            IdSexo = eSexo.Masculino;
            IdEstadoCivil = eEstadoCivil.Soltero;
            IdNacionalidad = ePais.Peru;
            IdTipoPersona = eTipoPersona.Participante;
            IdEstado = eEstadoBasico.Activo;
        }
        public string PrimerNombre { get; set; }
        public string SegundoNombre { get; set; }
        public string PrimerApellido { get; set; }
        public string SegundoApelldio { get; set; }
        public DateTime? FechaNacimiento { get; set; }
        public eUbigeo? IdUbigeoNacimiento { get; set; }
        public eSexo? IdSexo { get; set; }
        public eEstadoCivil? IdEstadoCivil { get; set; }
        public ePais? IdNacionalidad { get; set; }
        public eTipoPersona? IdTipoPersona { get; set; }
        public eEstadoBasico? IdEstado { get; set; }

        public virtual Persona IdPersonaNavigation { get; set; }
        public virtual Ubigeo IdUbigeoNacimientoNavigation { get; set; }
    }
}
