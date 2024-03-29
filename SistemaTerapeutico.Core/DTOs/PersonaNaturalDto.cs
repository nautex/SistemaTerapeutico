﻿using System;

namespace SistemaTerapeutico.Core.DTOs
{
    public class PersonaNaturalDto
    {
        public int IdPersona { get; set; }
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
    }
}
