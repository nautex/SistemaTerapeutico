﻿using System;

namespace SistemaTerapeutico.Core.DTOs
{
    public class PersonaContactoViewDto
    {
        public int Id { get; set; }

        public int IdPersona { get; set; }
        public int Numero { get; set; }
        public int IdTipoContacto { get; set; }
        public string TipoContacto { get; set; }
        public string Valor { get; set; }
        public int IdEstado { get; set; }
        public DateTime? FechaRegistro { get; set; }
        public string UsuarioRegistro { get; set; }
        public DateTime? FechaModificacion { get; set; }
        public string UsuarioModificacion { get; set; }
    }
}
