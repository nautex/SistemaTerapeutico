using System;
using SistemaTerapeutico.Core.Enumerators;

namespace SistemaTerapeutico.Core.Entities
{
    public partial class PersonaNatural : BaseEntity
    {
        public PersonaNatural()
        {
            PrimerNombre = "";
            SegundoNombre = "";
            PrimerApellido = "";
            SegundoApellido = "";
            IdUbigeoNacimiento = EUbigeo.Tacna;
            IdSexo = ESexo.Masculino;
            IdEstadoCivil = EEstadoCivil.Soltero;
            IdNacionalidad = EPais.Peru;
            IdTipoPersona = ETipoPersona.Participante;
            IdEstado = EEstadoBasico.Activo;
        }
        public string PrimerNombre { get; set; }
        public string SegundoNombre { get; set; }
        public string PrimerApellido { get; set; }
        public string SegundoApellido { get; set; }
        public DateTime? FechaNacimiento { get; set; }
        public int? IdUbigeoNacimiento { get; set; }
        public int? IdSexo { get; set; }
        public int? IdEstadoCivil { get; set; }
        public int? IdNacionalidad { get; set; }
        public int? IdTipoPersona { get; set; }
        public int? IdEstado { get; set; }

        public virtual Persona Persona { get; set; }
        //public virtual Ubigeo IdUbigeoNacimientoNavigation { get; set; }
    }
}
