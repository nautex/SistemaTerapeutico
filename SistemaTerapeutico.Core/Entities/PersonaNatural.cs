﻿using System;
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
        public string SegundoApelldio { get; set; }
        public DateTime? FechaNacimiento { get; set; }
        public int? IdUbigeoNacimiento { get; set; }
        public int? IdSexo { get; set; }
        public int? IdEstadoCivil { get; set; }
        public int? IdNacionalidad { get; set; }
        public int? IdTipoPersona { get; set; }
        public int? IdEstado { get; set; }

        //public virtual Persona IdPersonaNavigation { get; set; }
        //public virtual Ubigeo IdUbigeoNacimientoNavigation { get; set; }
    }
}
