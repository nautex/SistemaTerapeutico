﻿using System;

namespace SistemaTerapeutico.Core.Views
{
    public class PersonaNaturalView : BaseView
    {
        public string Nombres { get; set; }
        public DateTime FechaIngreso { get; set; }
        //public int IdPaisOrigen { get; set; }
        public bool EsEmpresa { get; set; }
        public string PrimerNombre { get; set; }
        public string SegundoNombre { get; set; }
        public string PrimerApellido { get; set; }
        public string SegundoApellido { get; set; }
        public DateTime? FechaNacimiento { get; set; }
        public int? IdPais { get; set; }
        public int? IdDepartamento { get; set; }
        public int? IdProvincia { get; set; }
        public int? IdUbigeoNacimiento { get; set; }
        public int? IdSexo { get; set; }
        public int? IdEstadoCivil { get; set; }
        //public int? IdNacionalidad { get; set; }
        public int? IdTipoPersona { get; set; }
        public int? IdEstado { get; set; }
    }
}
